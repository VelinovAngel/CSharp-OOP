using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Animals> animals = new List<Animals>();

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string typeAnimal = input;
                string[] tokensInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokensInfo[0];
                int age = int.Parse(tokensInfo[1]);
                string gender = tokensInfo[2];

                if (typeAnimal == "Dog")
                {
                    animals.Add(new Dog(name, age, gender));
                }
                else if (typeAnimal == "Cat")
                {
                    animals.Add(new Cat(name, age, gender));
                }
                else if (typeAnimal == "Frog")
                {
                    animals.Add(new Frog(name, age, gender));
                }
                else if (typeAnimal == "Tomcat")
                {
                    animals.Add(new Tomcats(name, age));
                }
                else if (typeAnimal == "Kitten")
                {
                    animals.Add(new Kitten(name, age));
                }
                //else
                //{
                //    Console.WriteLine("Invalid input!");
                //}

            }

            foreach (var type in animals)
            {
                Console.WriteLine(type.GetType().Name);
                Console.WriteLine($"{type.Name} {type.Age} {type.Gender}");
                Console.WriteLine($"{type.ProduceSound()}");
            }
        }
    }
}
