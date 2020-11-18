using System;
using System.Collections.Generic;
using System.Linq;
using _04.BorderControl.Interfaces;
using _04.BorderControl.Models;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentificable> all = new List<IIdentificable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    all.Add(new Citizen(name, age, id)); 
                }

                if (tokens.Length == 2)
                {
                    string name = tokens[0];
                    string id = tokens[1];

                    all.Add(new Robot(name, id));
                }       
            }

            string fakeId = Console.ReadLine();

            all.Where(c => c.Id.EndsWith(fakeId))
            .Select(c => c.Id)
            .ToList()
            .ForEach(Console.WriteLine);
        }
    }
}
