using System;
namespace Restaurant
{
    public class Cake : Dessert
    {
        new private const double Grams = 250;
        new private const double Calories = 1000;
        private const decimal CakePrice = 5m;

        public Cake(string name)
            : base(name, CakePrice, Grams, Calories)
        {

        }


    }
}

