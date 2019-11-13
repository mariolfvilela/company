using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Company.Domain.Common;
using DotNetCore.Objects;

namespace Company.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable
        where TEntity : EntityBase
    {
        /// <summary>
        /// Incluir um registro no banco de dados.
        /// </summary>
        /// <param name="entidade">Entidade a ser incluída.</param>
        /// <returns>A entidade incluída.</returns>
        //TEntity Add(TEntity entidade);
        Task<int> AddAsync(TEntity entidade);

        /// <summary>
        /// Excluir um registro no banco de dados.
        /// </summary>
        /// <param name="id">ID do registro a ser excluído.</param>
        //void Remove(int id);
        Task<bool> RemoveByIdAsync(int id);

        /// <summary>
        /// Excluir um registro no banco de dados.
        /// </summary>
        /// <param name="entidade">Entidade a ser excluída.</param>
        Task<bool> RemoveAsync(TEntity entidade);

        /// <summary>
        /// Alterar um registro no banco de dados.
        /// </summary>
        /// <param name="entidade">Entidade a ser alterada.</param>
        /// <returns>A entidade alterada.</returns>
        Task<TEntity> UpdateAsync(TEntity entidade);

        /// <summary>
        /// Selecionar um registro no banco de dados.
        /// </summary>
        /// <param name="id">ID do registro a ser retornado.</param>
        /// <returns>Entidade do registro encontrado.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Selecionar todos os registros no banco de dados para uma determinada entidade.
        /// </summary>
        /// <returns>Uma listagem dos registros encontrados.</returns>
        //IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> ListAsync();

        Task<PagedList<TEntity>> ListAsync(PagedListParameters parameters);
    }
}
