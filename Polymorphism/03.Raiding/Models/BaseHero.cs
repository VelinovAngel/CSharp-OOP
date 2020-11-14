using System;
using System.Collections.Generic;

namespace _03.Raiding.Models
{
    public abstract class BaseHero
    {
        private const string INV_HERO = "Invalid hero!";

        private ICollection<BaseHero> heroes;



        protected BaseHero(string name)
        {
            this.Name = name;
            heroes = new List<BaseHero>();
        }

        public string Name { get; }

        protected abstract int Power { get; }

        protected IReadOnlyCollection<BaseHero> Heros
        {
            get
            {
                return (IReadOnlyCollection<BaseHero>)this.heroes;
            }
            private set
            {
                ValidationHero(value, GetType().Name);

                this.heroes = (ICollection<BaseHero>)value;
            }
        }

        public abstract string CastAbility();

        private IReadOnlyCollection<BaseHero> ValidationHero(IReadOnlyCollection<BaseHero> value , string typeHero)
        {
            switch (typeHero)
            {
                case "Druid": 
                    return value;
                case "Paladin":
                    return value;
                case "Rogue":
                    return value;
                case "Warrior":
                    return value;
                default:
                    throw new InvalidOperationException(INV_HERO);
                    
            }
        }

        public void Add(BaseHero hero)
        {
            heroes.Add(hero);
        }
    }
}
