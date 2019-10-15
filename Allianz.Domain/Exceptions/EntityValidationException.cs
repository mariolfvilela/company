using System;
using System.Collections.Generic;

namespace Allianz.Domain.Exceptions
{
    /// <summary>
    /// Classe para tratamento das exceções.
    /// </summary>
    public sealed class EntityValidationException : Exception
    {
        /// <summary>
        /// Mensagem tratada.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Lista de itens para serem exibidos como detalhes da mensagem.
        /// </summary>
        public List<string> Mensagens { get; set; }

        /// <summary>
        /// Dados que geraram a exceção.
        /// </summary>
        public object Dados { get; set; }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="label">Mensagem tratada.</param>
        /// <param name="errorMessage">Exceção gerada pela aplicação.</param>
        /// <param name="dados">Dados que geraram a exceção.</param>
        public EntityValidationException(string label, string errorMessage, object dados)
            : base(errorMessage)
        {
            Label = label;
            Dados = dados;
        }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="label">Mensagem tratada.</param>
        /// <param name="errorMessage">Exceção gerada pela aplicação.</param>
        /// <param name="mensagens">Lista de itens para serem exibidos como detalhes da mensagem.</param>
        public EntityValidationException(string label, string errorMessage, List<string> mensagens)
            : base(errorMessage)
        {
            Label = label;
            Mensagens = mensagens;
        }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="label">Mensagem tratada.</param>
        /// <param name="errorMessage">Exceção gerada pela aplicação.</param>
        public EntityValidationException(string label, string errorMessage)
            : this(label, errorMessage, null)
        {
        }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="errorMessage">Exceção gerada pela aplicação.</param>
        public EntityValidationException(string errorMessage)
            : this(string.Empty, errorMessage)
        {
        }
    }
}
