using System;

using _04.WildFarm.Models.Foods.Interfaces;

namespace _04.WildFarm.Models.Foods
{
    public abstract class Food : IFoods
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
