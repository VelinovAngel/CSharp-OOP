using System;
using System.Collections.Generic;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int CAPACITY_VALUE = 10;
        private readonly IDictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots
            => (IReadOnlyDictionary<string, IRobot>)this.robots;



        public void Manufacture(IRobot robot)
        {
            if (robots.Count == CAPACITY_VALUE)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            robots[robotName].Owner = ownerName;
            robots[robotName].IsBought = true;
            robots.Remove(robotName);
        }
    }
}
