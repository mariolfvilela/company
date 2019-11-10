using System;
using Company.Application.Interfaces;
using Company.Application.ViewModels;
using Company.Domain.Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    
    public abstract class BaseController<Entity, EntityViewModel> : ControllerBase
        where Entity : EntityBase
        where EntityViewModel : ViewModelBase
    {
        readonly protected IAppServicoBase<Entity, EntityViewModel> app;

        protected BaseController(IAppServicoBase<Entity, EntityViewModel> app)
        {
            this.app = app;
        }
        
    }
}
