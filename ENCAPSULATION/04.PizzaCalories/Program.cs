using System;
using System.Linq;
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
                string[] pizzaTokens = Console.ReadLine().
                    Split(" ");

                string pizzaName = pizzaTokens[1];

                string[] doughTokens = Console.ReadLine().
                    Split(" ");

                string doughName = doughTokens[1];
                string bakeType = doughTokens[2];
                double doughWeight = double.Parse(doughTokens[3]);

                Dough dough = new Dough(doughName, bakeType, doughWeight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string command = Console.ReadLine();

                while (command.ToUpper() != "END")
                {
                    string[] toppingTokens = command.
                        Split(" ");

                    string toppingName = toppingTokens[1];
                    double toppingWeight = double.Parse(toppingTokens[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.Add(topping);

                    command = Console.ReadLine();
                }

                Console.WriteLine(pizza);

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }
    }
}
