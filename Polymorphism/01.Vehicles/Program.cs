using System;
using System.Linq;
using _01.Vehicles.Models;

namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] infoCar = Console.ReadLine()
                .Split()
                .ToArray();
            double fuelCar = double.Parse(infoCar[1]);
            double distanceCar = double.Parse(infoCar[2]);

            string[] infoTruck = Console.ReadLine()
                .Split()
                .ToArray();
            double fuelTruck = double.Parse(infoTruck[1]);
            double distanceTruck = double.Parse(infoTruck[2]);

            IVehicle car = new Car(fuelCar, distanceCar);
            IVehicle truck = new Truck(fuelTruck, distanceTruck);
     
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split()
                    .ToArray();

                string options = command[0];
                string type = command[1];
                double distance = double.Parse(command[2]);

                if (options.ToLower() == "drive")
                {
                    if (type.ToLower() == "car")
                    {
                        car.Drive(distance);
                    }
                    else if(type.ToLower() == "truck")
                    {
                        truck.Drive(distance);
                    }
                }
                else if (options.ToLower() == "refuel")
                {
                    if (type.ToLower() == "car")
                    {
                        car.Refuel(distance);
                    }
                    else if (type.ToLower() == "truck")
                    {
                        truck.Refuel(distance);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");

        }
    }
}
