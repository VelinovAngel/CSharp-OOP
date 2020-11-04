using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private ICollection<Product> bag;


        private Person()
        {
            this.bag = new List<Product>();
        }

        public Person(string name, decimal money)
            :this()
        {
            this.Name = name;
            this.Money = money;
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstans.EmptyNameExMSG);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstans.MoneyNegativeExMSG);
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return (IReadOnlyCollection<Product>)this.bag;
            }
        }


        public string BuyProduct(Product product)
        {
            if (this.money < product.Cost)
            {
                return $"{string.Format(GlobalConstans.NothingBoughtExMSG, this.Name, product.Name)}";
            }

            this.Money -= product.Cost;
            this.bag.Add(product);

            return $"{string.Format(GlobalConstans.BoughtPorduct, this.Name, product.Name)}";
        }

    }
}
