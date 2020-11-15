using System.Collections.Generic;

namespace _07.MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}
