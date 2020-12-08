using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedures
    {
        private const int HAPPINESS_VALUE = 5;
        private const bool CHIPPED_VALUE = true;

        public Chip()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChipped)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }

            robot.Happiness -= HAPPINESS_VALUE;
            robot.IsChipped = CHIPPED_VALUE;

            Robots.Add(robot);
        }
    }
}
