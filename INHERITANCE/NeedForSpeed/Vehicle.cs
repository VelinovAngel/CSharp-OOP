using System;
namespace NeedForSpeed
{
    public class Vehicle
    {
        private double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }


        public virtual double FuelConsumption { get; set; }

        public virtual double DefaultFuelConsumption
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

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers;
        }
    }
}
