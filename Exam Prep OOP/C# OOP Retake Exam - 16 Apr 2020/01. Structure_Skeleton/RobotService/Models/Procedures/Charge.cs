using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedure
    {
        private const int HAPPINESS_VALUE = 12;
        private const int ENERGY_VALUE = 10;

        //•	Charge – adds 12 happiness and 10 energy

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness += HAPPINESS_VALUE;
            robot.Energy += ENERGY_VALUE;

            Robots.Add(robot);
        }
    }
}
