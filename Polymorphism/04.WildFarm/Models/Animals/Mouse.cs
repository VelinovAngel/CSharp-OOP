using System;
using System.Collections.Generic;

using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Mouse : Memmal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.10;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>() { typeof(Vegetable), typeof(Fruit) };

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
