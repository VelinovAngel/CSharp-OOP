using System;
namespace _03.Raiding.Models
{
    public class Druid : BaseHero
    {
        private int power = 80;


        public Druid(string name)
            : base(name)
        {
        }

        protected override int Power => this.power; 

        public override string CastAbility()
        {
            return $"{GetType().Name} – {this.Name} healed for {power}";
        }
    }
}

