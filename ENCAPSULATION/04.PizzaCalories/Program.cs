using System;
using _04.PizzaCalories.Models;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dough dough = new Dough("Margherita", "gosho", 2.20); 
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
