using System;
using System.Linq;
using System.Text;



using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.Core.Factories;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.BattleFields;
using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core
{

    public class ManagerController : IManagerController
    {
        private ICard card;
        private IPlayer player;
        private IBattleField battleField;
        private ICardFactory cardFactory;
        private IPlayerFactory playerFactory;
        private ICardRepository cardRepository;
        private IPlayerRepository playerRepository;
        //private readonly ICollection<ICard> cards;
        //private readonly ICollection<IPlayer> players;

        public ManagerController()
        {
            //cards = new List<ICard>();
            //players = new List<IPlayer>();
            cardFactory = new CardFactory();
            playerFactory = new PlayerFactory();
            battleField = new BattleField();
            cardRepository = new CardRepository();
            playerRepository = new PlayerRepository();

        }

        public string AddPlayer(string type, string username)
        {
            player = playerFactory.CreatePlayer(type, username);

            playerRepository.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            card = cardFactory.CreateCard(type, name);

            if (card != null)
            {
                if (!cardRepository.Cards.Contains(card))
                {

                    cardRepository.Add(card);
                }
            }

            return $"Successfully added card of type {type}Card with name: {name}";

        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer currPlayer = playerRepository.Players.FirstOrDefault(x => x.Username == username);
            ICard currCard = cardRepository.Cards.FirstOrDefault(x => x.Name == cardName);


            currPlayer.CardRepository.Add(currCard);
            return $"Successfully added card: {cardName} to user: {currPlayer.Username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = playerRepository.Players.FirstOrDefault(x => x.Username == attackUser);
            IPlayer enemy = playerRepository.Players.FirstOrDefault(x => x.Username == enemyUser);

            if (attacker != null && enemy != null)
            {
                battleField.Fight(attacker, enemy);
            }

            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
