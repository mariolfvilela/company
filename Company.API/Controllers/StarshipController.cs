using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Application.Interfaces;
using Company.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StarshipController : Controller
    {
        // https://swapi.co
        // https://github.com/phalt/swapi
        // https://github.com/scharamoose/In-a-galaxy-far-far-away


        [HttpGet]
        [Route("{valor:int}")]
        public async Task<IEnumerable<StarshipViewModel>> ListAsync([FromServices]IStarshipAppService repository, int valor)
        {
            return await repository.Get(valor);
        }
    }
}
