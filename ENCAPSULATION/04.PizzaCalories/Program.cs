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
                double value = dough.DoughCalories();
                Console.WriteLine($"{value:f2}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
