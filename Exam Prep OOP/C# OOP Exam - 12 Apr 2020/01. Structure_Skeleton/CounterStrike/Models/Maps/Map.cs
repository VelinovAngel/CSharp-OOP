using System.Linq;
using System.Collections.Generic;

using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            ICollection<IPlayer> terrorists = players
                .Where(tr => tr.GetType() == typeof(Terrorist))
                .ToList();

            ICollection<IPlayer> counterTerrorists = players
                .Where(ct => ct.GetType() == typeof(CounterTerrorist))
                .ToList();

            while (terrorists.Any(c=>c.IsAlive) && counterTerrorists.Any(x=>x.IsAlive))
            {
                foreach (IPlayer terrorist in terrorists.Where(x=>x.IsAlive))
                {
                    foreach (IPlayer counterTerrorist in counterTerrorists.Where(x=>x.IsAlive))
                    {
                        counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                    }
                }

                foreach (IPlayer counterTerrorist in counterTerrorists.Where(x => x.IsAlive))
                {
                    foreach (IPlayer terrorist in terrorists.Where(x => x.IsAlive))
                    {
                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                    }
                }
            }

            if (counterTerrorists.Any(x=>x.IsAlive))
            {
                return "Counter Terrorist wins!";
            }
            else 
            {
                return "Terrorist wins!";
            }
        }
    }
}
