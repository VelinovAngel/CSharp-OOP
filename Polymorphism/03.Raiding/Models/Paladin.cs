using System;
namespace _03.Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
            : base(name)
        {
        }

        public override string CastAbility()
        {
            throw new NotImplementedException();
        }
    }
}
