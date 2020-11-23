using System;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }

        public IGun Gun
        {
            get
            {
                return this.gun;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.gun = value;
            }
        }

        public bool IsAlive
          => this.Health > 0 ? true : false;

        public void TakeDamage(int points)
        {
            if (this.Armor > 0)
            {
                int armor = this.Armor - points;
                if (armor > 0)
                {
                    this.Armor -= points;
                }
                else
                {
                    int dmgWithoutArmor = Math.Abs(this.Armor - points);
                    this.Armor = 0;
                    this.Health -= dmgWithoutArmor;
                }
            }
            else
            {
                if (this.Health - points < 0)
                {
                    this.Health = 0;
                }
                this.Health -= points;
            }

        }
    }
}
