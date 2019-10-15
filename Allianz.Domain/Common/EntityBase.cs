using System;
namespace Allianz.Domain.Common
{
    /// <summary>
    /// Entidade base.
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// Identificação (Identity)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data de criação do registro.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Data de alteração do registro.
        /// </summary>
        public DateTime? LastModified { get; set; }
    }
}
