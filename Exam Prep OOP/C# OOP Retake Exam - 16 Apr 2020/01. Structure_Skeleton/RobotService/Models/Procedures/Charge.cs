using System;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedures
    {
        private const int HAPPINESS_VALUE = 12;
        private const int ENERGY_VALUE = 10;

        public Charge()
        {

        }

        //•	Charge – adds 12 happiness and 10 energy

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy += ENERGY_VALUE;
            robot.Happiness += HAPPINESS_VALUE;

            Robots.Add(robot);
        }
    }
}
