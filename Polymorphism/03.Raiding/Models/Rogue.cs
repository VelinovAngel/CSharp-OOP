using System;
namespace _03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
            :base(name, 80)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} – {this.Name} hit for {this.Power} demage";
        }
    }
}
