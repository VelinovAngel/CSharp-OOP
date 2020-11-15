using System;
using System.Linq;
using System.Reflection;
using _04.WildFarm.Common;
using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string strType, int quantity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == strType);

            if (type == null)
            {
                throw new InvalidOperationException(ExceptionMesseges.INV_ANIMAL_TYPE);
            }

            object[] ctorParams = new object[] { quantity };

            Food food = (Food)Activator.CreateInstance(type, ctorParams);

            return food;

        }
    }
}
