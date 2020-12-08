using System;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedures
    {
        public Charge()
        {

        }

        //•	Charge – adds 12 happiness and 10 energy

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy += 10;
            robot.Happiness += 12;

            Robots.Add(robot);
        }
    }
}
