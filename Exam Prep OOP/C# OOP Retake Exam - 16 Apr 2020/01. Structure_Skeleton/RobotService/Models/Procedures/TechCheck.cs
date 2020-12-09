using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        private const int ENERGY_VALUE = 8;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= ENERGY_VALUE;
            robot.IsChecked = true;

            Robots.Add(robot);
        }
    }
}
