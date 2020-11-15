using System;
using System.Collections.Generic;
using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Dog : Memmal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.40;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>() { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
