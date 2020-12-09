using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Polish : Procedure
    {
        private const int HAPPINESS_VALUE = 7;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.ProcedureTime -= procedureTime;
            robot.Happiness -= HAPPINESS_VALUE;

            Robots.Add(robot);
        }
    }
}
