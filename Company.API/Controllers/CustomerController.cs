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
    public class CustomerController : BaseController<Customer, CustomerViewModel>
    {
        public CustomerController(ICustomerAppService app)
            : base(app)
        { }

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
    }
}
