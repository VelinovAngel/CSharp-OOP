using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;

            if (type == nameof(Advanced))
            {
                player = new Advanced(new CardRepository(), username);
            }

            if (type == nameof(Beginner))
            {
                player = new Beginner(new CardRepository(), username);
            }

            return player;
        }
    }
}
