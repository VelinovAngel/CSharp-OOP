using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(25, 45);

            vehicle.Drive(3);
        }
    }
}
