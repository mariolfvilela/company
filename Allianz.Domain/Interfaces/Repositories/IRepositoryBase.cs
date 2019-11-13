using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Domain.Common;

namespace Company.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de repositório base.
    /// </summary>
    /// <typeparam name="TEntity">Entidade que implementará o repositório base.</typeparam>
    public interface IRepositoryBase<TEntity> : IDisposable
        where TEntity : EntityBase
    {
        /// <summary>
        /// Incluir um registro no banco de dados.
        /// </summary>
        /// <param name="entidade">Entidade a ser incluída.</param>
        /// <returns>A entidade incluída.</returns>
        int Add(TEntity entidade);

        /// <summary>
        /// Excluir um registro no banco de dados.
        /// </summary>
        /// <param name="id">ID do registro a ser excluído.</param>
        void RemoveById(int id);

        /// <summary>
        /// Excluir um registro no banco de dados.
        /// </summary>
        /// <param name="entidade">Entidade a ser excluída.</param>
        void Remove(TEntity entidade);

        /// <summary>
        /// Alterar um registro no banco de dados.
        /// </summary>
        /// <param name="entidade">Entidade a ser alterada.</param>
        /// <returns>A entidade alterada.</returns>
        TEntity Update(TEntity entidade);

        /// <summary>
        /// Selecionar um registro no banco de dados.
        /// </summary>
        /// <param name="id">ID do registro a ser retornado.</param>
        /// <returns>Entidade do registro encontrado.</returns>
        //TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Selecionar todos os registros no banco de dados para uma determinada entidade.
        /// </summary>
        /// <returns>Uma listagem dos registros encontrados.</returns>
        //IQueryable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> ListAsync();
    }
}
