using System.Collections.Generic;
using Company.Domain.Common;

namespace Company.Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Address;
        }

        protected IEnumerable<object> GetEquals()
        {
            yield return Address;
        }
    }
}
