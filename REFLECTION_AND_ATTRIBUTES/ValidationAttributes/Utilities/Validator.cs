using System;
using System.Reflection;

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

            foreach (PropertyInfo property in properties )
            {

            }
        }
    }
}
