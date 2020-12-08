using System;
namespace RobotService.Models.Robots
{
    public class WalkerRobot : Robots
    {
        public WalkerRobot(string name, int energy, int happiness, int procedureTime)
            : base(name, energy, happiness, procedureTime)
        {
        }
    }
}
