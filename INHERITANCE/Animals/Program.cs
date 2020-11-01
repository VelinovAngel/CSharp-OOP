using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Animal> animals = new List<Animal>();

            while ((input = Console.ReadLine()) != "Beast!")
            {

                string typeAnimal = input;
                string[] tokensInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokensInfo[0];
                int age = int.Parse(tokensInfo[1]);
                string gender = tokensInfo[2];


                Animal animal;

                if (typeAnimal == "Dog")
                {
                    animal = new Dog(name, age, gender);

                }
                else if (typeAnimal == "Cat")
                {
                    animal = new Cat(name, age, gender);
                }
                else if (typeAnimal == "Frog")
                {
                    animal = new Frog(name, age, gender);
                }
                else if (typeAnimal == "Tomcat")
                {
                    animal = new Tomcat(name, age);
                }
                else if (typeAnimal == "Kitten")
                {
                    animal = new Kitten(name, age);
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }

                animals.Add(animal);

            }
            foreach (var type in animals)
            {
                Console.WriteLine(type);
            }
        }
    }
}
