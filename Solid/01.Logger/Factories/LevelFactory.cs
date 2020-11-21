using System;
using System.Reflection;
using _01.Logger.Models.Contracts;

namespace _01.Logger.Factories
{
    public class LevelFactory
    {
        public LevelFactory()
        {
        }

        public ILayout CreateLayout(string layoutTypeStr)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type layoutType = assembly.GetType().FirstOrDefault
        }
    }
}
