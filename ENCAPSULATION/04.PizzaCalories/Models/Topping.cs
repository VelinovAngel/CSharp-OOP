using System;
using _04.PizzaCalories.ExeptionMSG;

namespace _04.PizzaCalories.Models
{
    public class Topping
    {
        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                ValidationTopping(value);

                this.toppingType = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                ValidationWeight(value, this.toppingType);

                this.weight = value;
            }
        }

        private void ValidationWeight(double type , string name)
        {
            if (type < 1 || type > 50)
            {
                throw new ArgumentException(string.Format(GlobalExeptions.ToppingTypeOutOfRangeExp, name));
            }
        }

        private void ValidationTopping(string type)
        {
            string currType = type.ToLower();
            if (currType != "meat" && currType != "veggies" && currType != "cheese" && currType != "sauce")
            {
                throw new ArgumentException(string.Format(GlobalExeptions.InvalidToppingExp, type));
            }
        }

        private double ToppingTypeCalories()
        {
            string type = this.toppingType.ToLower();
            if (type == "meat")
            {
                return 1.2;
            }
            else if (type == "veggies")
            {
                return 0.8;
            }
            else if (type == "cheese")
            {
                return 1.1;
            }
            else
            {
                return 0.9;
            }
        }

        public double CalculateCalories()
        {
            return 2 * ToppingTypeCalories() * this.weight;
        }


    }
}
