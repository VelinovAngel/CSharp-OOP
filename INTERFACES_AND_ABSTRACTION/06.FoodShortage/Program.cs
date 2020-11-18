using System;
using System.Linq;
using System.Collections.Generic;

using _06.FoodShortage.Interfaces;
using _06.FoodShortage.Models;

namespace _06.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    buyers.Add(new Citizen(name, age, id, birthdate));
                }

                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    buyers.Add(new Rebel(name, age, group));
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(x => x.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
            Console.WriteLine(buyers.Sum(x=>x.Food));
        }
    }
}
