using System;
namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BulletsFiredPistol = 1;

        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount > 0)
            {
                this.BulletsCount -= BulletsFiredPistol;
                return BulletsFiredPistol;
            }
            return 0;
        }
    }
}
