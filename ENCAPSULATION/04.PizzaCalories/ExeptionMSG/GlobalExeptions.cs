using System;
namespace _04.PizzaCalories.ExeptionMSG
{
    public static class GlobalExeptions
    {
        public const string InvTypeDough = "Invalid type of dough.";
        public const string OutSideRange = "Dough weight should be in the range [1..200].";
        public const string InvalidToppingExp = "Cannot place {0} on top of your pizza.";
        public const string ToppingTypeOutOfRangeExp = "{0} weight should be in the range [1..50].";
        public const string NamePizzaLongerExp = "Pizza name should be between 1 and 15 symbols.";

    }
}
