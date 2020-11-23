using System;
namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BulletsFiredPistola = 1;
        private const string NameGun = "Pistol";

        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount >= BulletsFiredPistola)
            {
                if (this.GetType().Name == NameGun)
                {
                    BulletsCount -= BulletsFiredPistola;
                    return BulletsFiredPistola;
                }
            }
            return 0;
        }
    }
}
