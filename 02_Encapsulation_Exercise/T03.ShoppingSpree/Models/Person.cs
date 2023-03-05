using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree.Models
{
    internal class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameExceptionMessage);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.MoneyExceptionMessage);
                }

                this.money = value;
            }
        }

        public string Buy(Product product)
        {
            if (this.Money < product.Cost)
            {
                return $"{this.Name} can't afford {product}";
            }

            this.Money -= product.Cost;
            products.Add(product);
            
            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            string productString = string.Empty;

            if (products.Any())
            {
                productString = string.Join(", ", products);
            }
            else
            {
                productString = "Nothing bought";
            }

            return $"{this.Name} - {productString}";
        }
    }
}
