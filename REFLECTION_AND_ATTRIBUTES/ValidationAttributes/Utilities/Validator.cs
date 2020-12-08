using System;
using System.Linq;

using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Type objType = obj.GetType();

            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute[] attributes = property.GetCustomAttribute().
                                                             .Where(ca => ca is MyValidationAttribute)
                                                             .Cast<MyValidationAttribute>()
                                                             .ToArray();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (attribute.IsValid())
                    {

                    }
                }
            }


        }
    }
}
