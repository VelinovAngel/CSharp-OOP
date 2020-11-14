using System;
using System.Collections.Generic;
using _03.Raiding.Models;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {

            BaseHero baseHero = new Druid("Gosho");

            baseHero.Add(new Druid("Pesho"));
        }
    }
}
