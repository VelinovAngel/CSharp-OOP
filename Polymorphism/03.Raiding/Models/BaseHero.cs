using System;
using System.Collections.Generic;
using _03.Raiding.Interfaces;

namespace _03.Raiding.Models
{
    public abstract class BaseHero : ICastable
    {

        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; private set; }

        public int Power { get; private set; }

        public virtual string CastAbility()
        {
            return $"{GetType().Name} – {this.Name} healed for {this.Power}";
        }
    }
}
