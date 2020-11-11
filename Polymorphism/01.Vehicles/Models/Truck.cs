using System;
using _01.Vehicles.Constans;

namespace _01.Vehicles.Models
{
    public class Truck : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumpiton = fuelConsumption + 1.6; // Consumptions in litters per km
        }

        public double FuelQuantity { get => this.fuelQuantity; private set => this.fuelQuantity = value; }

        public double FuelConsumpiton { get => this.fuelConsumption; private set => this.fuelConsumption = value; }


        public void Drive(double distance)
        {
            double consumption = this.FuelConsumpiton * distance;
            if (this.FuelQuantity >= consumption)
            {
                this.FuelQuantity -= consumption;
                Console.WriteLine(string.Format(GlobalConstance.KM_TRAVELLED, this.GetType().Name, distance));
            }
            else
            {
                Console.WriteLine(string.Format(GlobalConstance.NEED_REFUELING, this.GetType().Name));
            }

        }

        public void Refuel(double fuel)
        {
            this.FuelQuantity += fuel * 0.95;
        }
    }
}
