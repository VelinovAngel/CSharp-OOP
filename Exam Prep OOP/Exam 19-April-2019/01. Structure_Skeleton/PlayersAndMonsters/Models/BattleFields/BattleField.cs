using System;
using System.Linq;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            //TODO
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;
                foreach (var playar in attackPlayer.CardRepository.Cards)
                {
                    playar.DamagePoints += 30;
                }
            }

            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;
                foreach (var playar in enemyPlayer.CardRepository.Cards)
                {
                    playar.DamagePoints += 30;
                }
            }

            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Select(x => x.HealthPoints).Sum();
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(x => x.HealthPoints).Sum();


            while (true)
            {
                var dmgAttack = attackPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum();
                enemyPlayer.TakeDamage(dmgAttack);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                var dmgEnemy = enemyPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum();
                attackPlayer.TakeDamage(dmgEnemy);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
