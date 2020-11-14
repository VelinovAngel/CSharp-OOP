using System;
using System.Collections.Generic;
using System.Linq;
using _03.Raiding.Factory;
using _03.Raiding.Models;

namespace _03.Raiding.Core
{
    public class Engine
    {
        private ICollection<BaseHero> heroes;

        public Engine()
        {
            heroes = new List<BaseHero>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());
            int counter = 0;

            while (lines != counter)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {

                    BaseHero baseHero = FactoryHeros.CreateHero(type, name);
                    heroes.Add(baseHero);
                    counter++;

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }

            double bossPower = double.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int sumHeroPower = heroes.Sum(x => x.Power);

            if (sumHeroPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
