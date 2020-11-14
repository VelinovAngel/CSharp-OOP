using System;
namespace _03.Raiding.Models
{
    public abstract class BaseHero
    {

        protected BaseHero(string name , int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get;}

        public int Power { get;}

        public string CastAbility()
        {
            return $"{GetType().Name} – {this.Name}";
        }
        
    }
}
