namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BulletsFiredRifle = 10;
        private const string NameGun = "Rifle";

        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount >= BulletsFiredRifle)
            {
                if (this.Name == NameGun)
                {
                    BulletsCount -= BulletsFiredRifle;
                    return BulletsFiredRifle;
                }
            }
            return 0;
        }
    }
}
