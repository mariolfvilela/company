using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Company.Application.ViewModels;

namespace Company.Application.Interfaces
{
    public interface IStarshipAppService
    {
        Task<IEnumerable<StarshipViewModel>> Get(int valor = 1000);
    }    
}
