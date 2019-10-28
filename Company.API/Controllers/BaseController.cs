using System;
using Company.Application.Interfaces;
using Company.Application.ViewModels;
using Company.Domain.Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class BaseController<Entity, EntityViewModel> : Controller
        where Entity : EntityBase
        where EntityViewModel : ViewModelBase
    {
        readonly protected IAppServiceBase<Entity, EntityViewModel> app;

        public BaseController(IAppServiceBase<Entity, EntityViewModel> app)
        {
            this.app = app;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                return new OkObjectResult(app.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return new OkObjectResult(app.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] EntityViewModel dado)
        {
            try
            {
                return new OkObjectResult(app.add(dado));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] EntityViewModel dado)
        {
            try
            {
                app.Update(dado);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Excluir(Guid id)
        {
            try
            {
                app.Remove(id);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
