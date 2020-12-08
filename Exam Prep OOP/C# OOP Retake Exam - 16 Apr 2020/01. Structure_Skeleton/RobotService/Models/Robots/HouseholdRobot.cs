namespace RobotService.Models.Robots
{
    public class HouseholdRobot : Robots
    {
        public HouseholdRobot(string name, int energy, int happiness, int procedureTime)
            : base(name, energy, happiness, procedureTime)
        {
        }
    }
}
