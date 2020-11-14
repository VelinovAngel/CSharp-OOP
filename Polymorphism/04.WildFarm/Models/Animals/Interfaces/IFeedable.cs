using System;
using System.Collections.Generic;

using _04.WildFarm.Models.Foods.Interfaces;

namespace _04.WildFarm.Models.Animals.Interfaces
{
    public interface IFeedable
    {
        void Feed(IFood food);

        int FoodEaten { get; }

        double WeightMultiplier { get; }

        ICollection<Type> PreferredFoods { get; }
    }
}
