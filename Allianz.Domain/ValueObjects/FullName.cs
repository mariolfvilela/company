using System.Collections.Generic;
using Company.Domain.Common;

namespace Company.Domain.ValueObjects
{
    public sealed class FullName : ValueObject
    {
        public FullName(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; }

        public string Surname { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Surname;
        }

        protected  IEnumerable<object> GetEquals()
        {
            yield return Name;
            yield return Surname;
        }
    }
}
