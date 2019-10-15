using System;
using System.Collections.Generic;

namespace Company.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntidade> : IDisposable
        where TEntidade : class
    {
        /// <summary>
        /// Incluir um registro no banco de dados.
        /// </summary>
        /// <param name="entidade">Entidade a ser incluída.</param>
        /// <returns>A entidade incluída.</returns>
        TEntidade Add(TEntidade entidade);

        /// <summary>
        /// Excluir um registro no banco de dados.
        /// </summary>
        /// <param name="id">ID do registro a ser excluído.</param>
        void Remove(int id);

        /// <summary>
        /// Excluir um registro no banco de dados.
        /// </summary>
        /// <param name="entidade">Entidade a ser excluída.</param>
        void Excluir(TEntidade entidade);

        /// <summary>
        /// Alterar um registro no banco de dados.
        /// </summary>
        /// <param name="entidade">Entidade a ser alterada.</param>
        /// <returns>A entidade alterada.</returns>
        TEntidade Update(TEntidade entidade);

        /// <summary>
        /// Selecionar um registro no banco de dados.
        /// </summary>
        /// <param name="id">ID do registro a ser retornado.</param>
        /// <returns>Entidade do registro encontrado.</returns>
        TEntidade GetById(int id);

        /// <summary>
        /// Selecionar todos os registros no banco de dados para uma determinada entidade.
        /// </summary>
        /// <returns>Uma listagem dos registros encontrados.</returns>
        IEnumerable<TEntidade> GetAll();
    }
}
