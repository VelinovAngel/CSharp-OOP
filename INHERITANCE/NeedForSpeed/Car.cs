using System;
namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private double defaultFuelConsumption = 3;

        public Car(int horsePower, double fuel)
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
