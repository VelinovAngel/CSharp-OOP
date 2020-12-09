using System;
using System.Linq;
using System.Collections.Generic;

using RobotService.Models.Robots;
using RobotService.Models.Garages;
using RobotService.Core.Contracts;
using RobotService.Utilities.Enums;
using RobotService.Models.Procedures;
using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures.Contracts;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IDictionary<string, IProcedure> procedures;

        private IProcedure procedure;

        private readonly IGarage garage;

        public Controller()
        {
            garage = new Garage();

            procedures = new Dictionary<string, IProcedure>()
            {
                {"Charge", new Charge() },
                {"Chip", new Chip() },
                {"Polish", new Polish() },
                {"Rest", new Rest() },
                {"Work", new Work() },
                {"TechCheck", new TechCheck() }
            };
        }

        //NOTE: For each command except for "Manufacture" and "History", you must check if a robot with that name exist in the garage. If it doesn't, throw an ArgumentException with the message "Robot {robot name} does not exist".

        public string Manufacture(string robotTypeName, string name, int energy, int happiness, int procedureTime)
        {
            if (!Enum.TryParse(robotTypeName, out RobotType robotType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotTypeName));
            }

            IRobot robot = null;

            switch (robotType)
            {
                case RobotType.PetRobot:
                    robot = new PetRobot(name, energy, happiness, procedureTime );
                    break;
                case RobotType.HouseholdRobot:
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotType.WalkerRobot:
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
            }

            garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!garage.Robots.Any(x => x.Key == robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];

            //procedure = new Chip();
            //test.Add(procedure);
            procedure = procedures["Chip"];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!garage.Robots.Any(x => x.Key == robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            //procedure = new Polish();
            //test.Add(procedure);
            procedure = procedures["Polish"];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!garage.Robots.Any(x => x.Key == robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            //procedure = new Rest();
            //test.Add(procedure);
            procedure = procedures["Rest"];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!garage.Robots.Any(x => x.Key == robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            //procedure = new TechCheck();
            //test.Add(procedure);
            procedure = procedures["TeckCheck"];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!garage.Robots.Any(x => x.Key == robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            //procedure = new Work();
            //test.Add(procedure);
            procedure = procedures["Work"];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        public string Charge(string robotName, int procedureTime)
        {
            if (!garage.Robots.Any(x => x.Key == robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            //procedure = new Charge();
            //test.Add(procedure);
            procedure = procedures["Charge"];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!garage.Robots.Any(x => x.Key == robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];

            garage.Sell(robotName, ownerName);

            string result = robot.IsChipped == true ? string.Format(OutputMessages.SellChippedRobot, ownerName) : string.Format(OutputMessages.SellNotChippedRobot, ownerName);

            return result;
        }

        public string History(string procedureType)
        {
            return procedures[procedureType].History();
        }
    }
}
