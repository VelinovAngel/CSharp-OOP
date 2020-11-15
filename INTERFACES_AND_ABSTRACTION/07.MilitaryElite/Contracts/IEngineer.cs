using System.Collections.Generic;

namespace _07.MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

    }
}
