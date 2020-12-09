using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Work : Procedure
    {
        private const int HAPPINESS_VALUE = 12;
        private const int ENERGY_VALUE = 6;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.ProcedureTime -= procedureTime;
            robot.Energy -= ENERGY_VALUE;
            robot.Happiness += HAPPINESS_VALUE;

            Robots.Add(robot);
        }
    }
}
