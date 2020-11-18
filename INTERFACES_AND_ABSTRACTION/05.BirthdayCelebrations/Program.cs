using System;
using System.Collections.Generic;
using System.Linq;
using _05.BirthdayCelebrations.Interfaces;
using _05.BirthdayCelebrations.Models;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirhdates> all = new List<IBirhdates>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdata = tokens[4];

                    all.Add(new Citizen(name, age, id , birthdata)); 
                }
                else if (tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];

                    all.Add(new Pet(name, birthdate));
                }   
            }

            int fakeId = int.Parse(Console.ReadLine());

            all.Where(c => c.Birthdate.Year == fakeId)
            .Select(c => c.Birthdate)
            .ToList()
            .ForEach(dt => Console.WriteLine($"{dt:dd/mm/yyyy}"));

        }
    }
}
