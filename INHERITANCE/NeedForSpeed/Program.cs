using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(25, 45);


            SportCar sportCar = new SportCar(50, 60);

            RaceMotorcycle raceMotorcyclec = new RaceMotorcycle(20, 30);

            Car car = new Car(10, 20);


            car.Drive(5);


        }
    }
}
