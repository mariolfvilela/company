using System;
using Company.Domain.Common;

namespace Company.Domain.Entities
{
    public class Product : EntityBase
    {
        private Product(){}

        public Product(Money price, string name, DateTime creationDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Price = price ?? throw new ArgumentNullException(nameof(price));
            Name = name;
            CreationDate = creationDate;
        }

        public Money Price { get; }
        public string Name { get; }        

        public override string ToString()
        {
            return $"product {Id} : \"{Name}\", costs {Price}";
        }
    }
}