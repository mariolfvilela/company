using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Application.Interfaces;
using Company.Application.ViewModels;
using Company.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseController<Customer, CustomerViewModel>
    {
        public CustomerController(ICustomerAppService app)
            : base(app)
        { }

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
        [Route("{id:guid}")]
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
        public IActionResult Incluir([FromBody] CustomerViewModel dado)
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
        public IActionResult Alterar([FromBody] CustomerViewModel dado)
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

        // [Authorize("Bearer")]
        [AllowAnonymous]
        [HttpGet]
        [Route("Teste")]
        public async Task<IActionResult> Teste()
        {

            return StatusCode(200,
                    new CustomerViewModel()
                    { }
                    );
        }

        

        // GET: api/Customer/5
        [HttpGet("teste/{id}")]
        public async Task<ActionResult<Customer>> GetTodoItem(long id)
        {
            var todoItem = 0;//await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return new OkObjectResult(0);// todoItem;
        }
    }
}
