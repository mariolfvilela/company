using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Company.Application.ViewModels;
using Company.Domain.Common;
using DotNetCore.Objects;

namespace Company.Application.Interfaces
{
    public interface IAppServicoBase<TEntity, TEntityViewModel>
        where TEntity : EntityBase
        where TEntityViewModel : ViewModelBase
    {
        //TEntityViewModel add(TEntityViewModel entityViewModel);
        //IEnumerable<TEntityViewModel> GetAll();
        //TEntityViewModel GetById(int id);
        //TEntityViewModel Update(TEntityViewModel entityViewModel);
        //void Remove(int id);

        Task<IDataResult<int>> AddAsync(TEntityViewModel entityViewModel);
        Task<IResult> RemoveByIdAsync(int id);
        Task<IResult> RemoveAsync(TEntityViewModel entityViewModel);
        Task<TEntityViewModel> UpdateAsync(TEntityViewModel entityViewModel);
        Task<TEntityViewModel> GetByIdAsync(int id);
        Task<IEnumerable<TEntityViewModel>> ListAsync();
        Task<PagedList<TEntityViewModel>> ListAsync(PagedListParameters parameters);
    }
}
