using System;
using _03.Raiding.Models;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            Druid druid = new Druid("Gosho");

            Console.WriteLine(druid.CastAbility());
        }
    }
}
