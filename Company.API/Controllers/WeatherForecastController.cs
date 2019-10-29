using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Application.Interfaces;
using Company.Application.ViewModels;
using Company.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Company.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController<Customer, CustomerViewModel>
    {
        public WeatherForecastController(ICustomerAppService app)
            : base(app)
        { }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        
    }
}
