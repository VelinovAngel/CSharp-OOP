using System;
using _04.PizzaCalories.Models;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dough Tip500 Chewy 100

            try
            {
                Dough dough = new Dough("White", "Chewy", 100);
                //double value = dough.DoughCalories();
                Console.WriteLine($"{dough.DoughCalories():f2}");

                //Topping meat 30
                Topping topping = new Topping("Meat", 30);
                Console.WriteLine($"{topping.CalculateCalories():f2}");

                Pizza pizza = new Pizza("asdasdasdasdasdasdsdas");

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
