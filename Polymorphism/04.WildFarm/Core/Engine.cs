using System;
using System.Linq;

using _04.WildFarm.Factories;
using System.Collections.Generic;
using _04.WildFarm.Core.Interface;
using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;

        public Engine()
        {

            this.animals = new HashSet<Animal>();
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalTokens = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                string type = animalTokens[0];
                string name = animalTokens[1];
                double weight = double.Parse(animalTokens[2]);
                string[] args = animalTokens
                    .Skip(3)
                    .ToArray();

                Animal animal = null;

                try
                {
                    animal = this.animalFactory.Create(type, name, weight, args);
                    this.animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                string[] foodTokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string foodType = foodTokens[0];
                int foodQuantity = int.Parse(foodTokens[1]);


                try
                {
                    Food food = this.foodFactory.CreateFood(foodType, foodQuantity);
                    if (animal != null)
                    {
                        animal.Feed(food);

                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
