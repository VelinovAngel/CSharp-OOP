using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Rest : Procedure
    {
        private const int HAPPINESS_VALUE = 3;
        private const int ENERGY_VALUE = 10;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.ProcedureTime -= procedureTime;
            robot.Happiness -= HAPPINESS_VALUE;
            robot.Energy += ENERGY_VALUE;

            Robots.Add(robot);
        }
    }
}
