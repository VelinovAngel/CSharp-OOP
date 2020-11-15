using System;
using System.Collections.Generic;

using _04.WildFarm.Models.Animals.Interfaces;
using _04.WildFarm.Models.Foods.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal, IFeedable, ISoundProducable
    {
        private const string INV_FOOD = "{0} does not eat {1}!";

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; private set;  }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract ICollection<Type> PreferredFoods { get; }

        public void Feed(IFood food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException(string.Format(INV_FOOD, this.GetType().Name, food.GetType().Name));
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
