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

            Pizza pizza;
            Dough dough;

            try
            {
                string[] input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                string namePizza = input[1];
                pizza = new Pizza(namePizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            try
            {
                string[] input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                string typeDough = input[1];
                string technique = input[2];
                double weight = double.Parse(input[3]);
                dough = new Dough(typeDough, technique, weight);

                pizza.PizzaDough = dough;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            string inputTopping = string.Empty;
            while ((inputTopping = Console.ReadLine()) != "END")
            {
                //Topping Sauce 20
                try
                {
                    string[] tokens = inputTopping
                        .Split(' ')
                        .ToArray();

                    string toppingName = tokens[1];
                    double toppingWeight = double.Parse(tokens[1]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.Add(topping);

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }
        }
    }
}
