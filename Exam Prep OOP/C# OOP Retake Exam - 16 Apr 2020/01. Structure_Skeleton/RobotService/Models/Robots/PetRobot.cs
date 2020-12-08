using System;
namespace RobotService.Models.Robots
{
    public class PetRobot : Robots
    {
        public PetRobot(string name, int energy, int happiness, int procedureTime)
            : base(name, energy, happiness, procedureTime)
        {
        }
    }
}
