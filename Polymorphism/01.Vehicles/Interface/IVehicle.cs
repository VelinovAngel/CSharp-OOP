using System;
namespace _01.Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get;}

        public double FuelConsumpiton { get;}

        public void Drive(double distance);

        public void Refuel(double fuel);

        
    }
}
