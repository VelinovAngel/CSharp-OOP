using System;
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
        private readonly Dictionary<ProcedureType, IProcedure> procedures;

        private readonly IGarage garage;

        public Controller()
        {
            garage = new Garage();
            this.procedures = new Dictionary<ProcedureType, IProcedure>();
            this.SeedProcedurs();

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

            IRobot robot = GetRobot(robotName);
            procedures[ProcedureType.Chip].DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            procedures[ProcedureType.TechCheck].DoService(robot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            procedures[ProcedureType.Polish].DoService(robot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            procedures[ProcedureType.Rest].DoService(robot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robotName);
        }


        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            procedures[ProcedureType.Work].DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            procedures[ProcedureType.Charge].DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = GetRobot(robotName);

            garage.Sell(robotName, ownerName);

            string result = robot.IsChipped == true ? string.Format(OutputMessages.SellChippedRobot, ownerName) : string.Format(OutputMessages.SellNotChippedRobot, ownerName);

            return result;
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureType procedureTypeEnum);
            IProcedure procedure = procedures[procedureTypeEnum];

            return procedure.History().Trim();
        }

        private void SeedProcedurs()
        {
            this.procedures.Add(ProcedureType.Charge, new Charge());
            this.procedures.Add(ProcedureType.Chip, new Chip());
            this.procedures.Add(ProcedureType.Polish, new Polish());
            this.procedures.Add(ProcedureType.Rest, new Rest());
            this.procedures.Add(ProcedureType.TechCheck, new TechCheck());
            this.procedures.Add(ProcedureType.Work, new Work());
        }

        private IRobot GetRobot(string name)
        {
            if (!garage.Robots.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, name));
            }

            return garage.Robots[name];
        }
    }
}
