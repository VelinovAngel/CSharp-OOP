using System;
using System.Collections.Generic;
using _04.PizzaCalories.ExeptionMSG;

namespace _04.PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private ICollection<Topping> toppings;

        public Pizza()
        {
            toppings = new List<Topping>();
        }

        public Pizza(string name)
            :this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                ValidationName(value);

                this.name = value;
            }
        }

        public Dough PizzaDough
        {
            get
            {
                return this.dough;
            }
            set
            {
                this.dough = value;
            }
        }

        public List<Topping> Topping { get; }

        public void Add(Topping topping)
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException(GlobalExeptions.OutOfRangeToppingExp);
            }
        }

        private void ValidationName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > 15)
            {
                throw new ArgumentException(GlobalExeptions.NamePizzaLongerExp);
            }
        }
    }
}
