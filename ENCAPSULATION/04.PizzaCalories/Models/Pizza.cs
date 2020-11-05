using System;
using System.Collections.Generic;
using System.Linq;
using _04.PizzaCalories.ExeptionMSG;

namespace _04.PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private readonly ICollection<Topping> toppings;

        //public Pizza()
        //{
        //    this.Toppings 
        //}

        public Pizza(string name , Dough dough)
            
        {
            this.Name = name;
            this.PizzaDough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
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

        public IReadOnlyCollection<Topping> Toppings
        {
            get
            {
                return (IReadOnlyCollection<Topping>)this.toppings;
            }
  
        }

        public void Add(Topping topping)
        {
            if (this.toppings.Count >= 10 || this.toppings.Count < 0)
            {
                throw new ArgumentException(GlobalExeptions.OutOfRangeToppingExp);
            }

            this.toppings.Add(topping);
        }

        private void ValidationName(string name)
        {
            if (name == string.Empty || name.Length > 15 )
            {
                throw new ArgumentException(GlobalExeptions.NamePizzaLongerExp);
            }
        }

        public override string ToString()
        {
            double calories = this.toppings.Sum(p => p.CalculateCalories());
            double totalCal = this.PizzaDough.DoughCalories() + calories;

            return $"{this.Name} - {totalCal:F2} Calories.";
        }
    }
}
