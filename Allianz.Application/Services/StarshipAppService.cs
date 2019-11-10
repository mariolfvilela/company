using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Company.Application.Interfaces;
using Company.Application.ViewModels;
using Newtonsoft.Json;

namespace Company.Application.Services
{
    public class StarshipAppService: IStarshipAppService
    {
        private static bool ValidInput => (Regex.IsMatch(Globals.MGLT, @"^\d+$") && long.TryParse(Globals.MGLT, out long n));

        public async Task<IEnumerable<StarshipViewModel>> Get(int valor = 1000)
        {
            return await GetStarshipAsync(ResultCallBack, valor);
        }

        private List<StarshipViewModel> Get2(int valor = 1000)
        {
            return GetStarshipAsync(ResultCallBack, valor).Result;
        }

        // https://swapi.co
        // https://github.com/phalt/swapi
        // https://github.com/scharamoose/In-a-galaxy-far-far-away
        private static async Task<List<StarshipViewModel>> GetStarshipAsync(Action<StarshipWrapper> callBack = null, int valor = 0)
        {
            List<StarshipViewModel> starships = new List<StarshipViewModel>();
            try
            {
                HttpClient httpClient = new HttpClient()
                {
                    BaseAddress = new Uri("http://swapi.co/api/starships/")
                };
                var nextUrl = httpClient.BaseAddress.ToString();


                Globals.MGLT = valor.ToString();

                do
                {
                    await httpClient.GetAsync(nextUrl)
                        .ContinueWith(async (starshipSearchTask) =>
                        {
                            var response = await starshipSearchTask;
                            if (response.IsSuccessStatusCode)
                            {
                                string asyncResponse = await response.Content.ReadAsStringAsync();
                                var result = JsonConvert.DeserializeObject<StarshipWrapper>(asyncResponse);
                                if (result != null)
                                {
                                // Build the entire list to return later after the loop.
                                if (result.Starships.Any())
                                        starships.AddRange(result.Starships.ToList());

                                    foreach (StarshipViewModel starship in starships)
                                    {
                                        starship.resupplyFrequency = CalculateResupplyFrequency(starship);
                                    }

                                // Run the callback method, passing the current result from the API.
                                callBack?.Invoke(result);

                                // Get the URL for the next page, where it exists.
                                nextUrl = result.Next ?? string.Empty;
                                }
                            }
                            else
                            {
                            // End loop if we get an error response.
                            nextUrl = string.Empty;
                            }
                        });
                    // while nextUrl contains a value, continue.
                } while (!string.IsNullOrEmpty(nextUrl));

            }
            catch
            {
                throw new Exception("Erro , conection....");
            }

            return starships;
        }

        private static void ResultCallBack(StarshipWrapper starshipSearchResult)
        {
            if (starshipSearchResult != null && starshipSearchResult.Count > 0)
            {
                int maxLengthStarshipName = starshipSearchResult.Starships.Aggregate((max, cur) => max.Name.Length > cur.Name.Length ? max : cur).Name.Length;
                int maxLengthStarshipRange = starshipSearchResult.Starships.Aggregate((max, cur) => max.MGLT.Length > cur.MGLT.Length ? max : cur).MGLT.Length;
                maxLengthStarshipRange = maxLengthStarshipRange > "unknown".Length ? maxLengthStarshipRange : "unknown".Length;
                int maxLengthStarshipResupplies = Globals.MGLT.Length > "unknown".Length ? Globals.MGLT.Length : "unknown".Length;


                foreach (var starship in starshipSearchResult.Starships)
                {
                    Console.WriteLine($"{starship.Name.PadRight(maxLengthStarshipName)} \t\tMGLT - {starship.MGLT.PadLeft(maxLengthStarshipRange)} \t\tNo. of Resupplies - { starship.resupplyFrequency.PadLeft(maxLengthStarshipResupplies) }");
                }
            }
        }

        public static string CalculateResupplyFrequency(StarshipViewModel starship)
        {
            // if "unknown", retrun "unknown"
            if (!Regex.IsMatch(starship.MGLT, @"^\d+$"))
            {
                return starship.MGLT;
            }

            DateTime JourneyStart = DateTime.Now;
            DateTime JourneyEnd = DateTime.Now;

            string[] tokenisedProvisionsOfConsumables = starship.consumables.Split(' ');

            switch (tokenisedProvisionsOfConsumables[1].ToLower())
            {
                case "day":
                case "days":
                    JourneyEnd = JourneyEnd.AddDays(Convert.ToDouble(tokenisedProvisionsOfConsumables[0]));
                    break;
                case "week":
                case "weeks":
                    JourneyEnd = JourneyEnd.AddDays(Convert.ToDouble(tokenisedProvisionsOfConsumables[0]) * 7);
                    break;
                case "month":
                case "months":
                    JourneyEnd = JourneyEnd.AddMonths(Convert.ToInt32(tokenisedProvisionsOfConsumables[0]));
                    break;
                case "year":
                case "years":
                    JourneyEnd = JourneyEnd.AddYears(Convert.ToInt32(tokenisedProvisionsOfConsumables[0]));
                    break;
            }

            int minutes = (int)(JourneyEnd - JourneyStart).TotalMinutes;
            int numHours = Enumerable.Range(0, minutes)
                .Select(min => JourneyStart.AddMinutes(min))
                // round to hour due to MGLT being the speed per hour
                .GroupBy(dt => new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0, 0))
                .Count();

            return (Convert.ToInt64(Globals.MGLT) / (numHours * Convert.ToInt64(starship.MGLT))).ToString();
        }
       
    }

    public static class Globals
    {
        private static string mGLT = String.Empty;

        public static string MGLT { get => mGLT; set => mGLT = value; }
    }

    public class StarshipWrapper
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<StarshipViewModel> Starships { get; set; }
    }
}
