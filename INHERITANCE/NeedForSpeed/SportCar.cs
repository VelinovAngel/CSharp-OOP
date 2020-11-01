using System;
namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private double defaultFuelConsumption = 10;
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        public override double DefaultFuelConsumption
        {
            get
            {
                return defaultFuelConsumption;
            }
            set
            {
                defaultFuelConsumption = value;
            }
        }
    }
}
