using System.Collections.Generic;
using _07.MilitaryElite.Contracts;

namespace _07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions =>
            (IReadOnlyCollection<IMission>)this.missions;

        public void AddMisions(IMission mission)
        {
            this.missions.Add(mission);
        }
    }
}
