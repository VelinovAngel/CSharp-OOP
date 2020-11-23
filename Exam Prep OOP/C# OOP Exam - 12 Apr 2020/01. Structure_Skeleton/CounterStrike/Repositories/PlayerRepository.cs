using System;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> playes;

        public PlayerRepository()
        {
            this.playes = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models
            => (IReadOnlyCollection<IPlayer>)this.playes;


        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            this.playes.Add(model);
        }

        public bool Remove(IPlayer model)
        {
            return this.playes.Remove(model);
        }

        public IPlayer FindByName(string name)
        {
            return this.playes.FirstOrDefault(x => x.Username == name);
        }
    }
}
