using System;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Models.Guns;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Players;

using CounterStrike.Repositories;

using CounterStrike.Core.Contracts;

using CounterStrike.Utilities.Messages;

using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts
    ;
using CounterStrike.Repositories.Contracts;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IGun> guns;
        private readonly IRepository<IPlayer> players;
        private readonly IMap maps;

        public Controller()
        {
            guns = new GunRepository();
            players = new PlayerRepository();
            maps = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun typeGun;

            if (type == nameof(Pistol))
            {
                typeGun = new Pistol(name, bulletsCount);
            }
            else if (type == nameof(Rifle))
            {
                typeGun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            guns.Add(typeGun);
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player;
            IGun gun = guns.f
            
            if (type == nameof(Terrorist))
            {
                player = new Terrorist(username, health, armor, );
            }
        }

        public string Report()
        {

        }

        public string StartGame()
        {

        }
    }
}
