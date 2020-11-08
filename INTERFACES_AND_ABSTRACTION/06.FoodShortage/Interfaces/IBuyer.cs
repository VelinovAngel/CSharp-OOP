using System;
namespace _06.FoodShortage.Interfaces
{
    public interface IBuyer
    {
        public int Food { get;}

        public string Name { get;}

        public void BuyFood();

    }
}
