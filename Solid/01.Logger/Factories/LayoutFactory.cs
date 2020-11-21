using System;
using System.Linq;
using System.Reflection;
using _01.Logger.Common;
using _01.Logger.Models.Contracts;

namespace _01.Logger.Factories
{
    public class LayoutFactory
    {
        public LayoutFactory()
        {
        }

        public ILayout CreateLayout(string layoutTypeStr)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type layoutType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name
                .Equals(layoutTypeStr,StringComparison.InvariantCultureIgnoreCase));

            if (layoutType == null)
            {
                throw new InvalidOperationException(GlobalConstans.InvalidLayoutType);
            }

            object[] ctorArg = new object[] { };

            ILayout layout = (ILayout)Activator.CreateInstance(layoutType, BindingFlags.Public | BindingFlags.Instance , ctorArg);

            return layout; 
        }
    }
}
