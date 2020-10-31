using System;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Gorilla gorilla = new Gorilla(name);
        }
    }
}
