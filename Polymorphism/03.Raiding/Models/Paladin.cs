using System;
namespace _03.Raiding.Models
{
    public class Paladin : BaseHero
    {
        private int power = 100;

        public Paladin(string name)
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
