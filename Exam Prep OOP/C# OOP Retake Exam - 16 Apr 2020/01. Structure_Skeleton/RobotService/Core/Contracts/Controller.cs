using System;


namespace RobotService.Core.Contracts
{
    public class Controller : IController
    {
        public string Charge(string robotName, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string Chip(string robotName, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string History(string procedureType)
        {
            throw new NotImplementedException();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string Polish(string robotName, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string Rest(string robotName, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string Sell(string robotName, string ownerName)
        {
            throw new NotImplementedException();
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            throw new NotImplementedException();
        }

        public string Work(string robotName, int procedureTime)
        {
            throw new NotImplementedException();
        }
    }
}
