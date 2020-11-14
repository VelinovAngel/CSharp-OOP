using System;
using _03.Raiding.Models;

namespace _03.Raiding.Factory
{
    public class FactoryHeros
    {
        private const string INV_OP = "Invalid hero!";

        public static BaseHero CreateHero(string heroType, string heroName)
        {
            BaseHero baseHero;

            switch (heroType)
            {
                case "Druid":
                    baseHero = new Druid(heroName);
                    break;
                case "Paladin":
                    baseHero = new Paladin(heroName);
                    break;
                case "Rogue":
                    baseHero = new Rogue(heroName);
                    break;
                case "Warrior":
                    baseHero = new Warrior(heroName);
                    break;
                default:
                    throw new InvalidOperationException(INV_OP);
            }
            return baseHero;
        }
    }
}
