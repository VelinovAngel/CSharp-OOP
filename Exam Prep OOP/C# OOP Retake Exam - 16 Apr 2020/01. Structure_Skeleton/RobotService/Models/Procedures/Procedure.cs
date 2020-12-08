using System;
using System.Text;
using System.Collections.Generic;

using RobotService.Models.Robots.Contracts;
using RobotService.Models.Procedures.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private ICollection<IRobot> robots;

        protected Procedure()
        {
            this.robots = new List<IRobot>();
        }

        protected List<IRobot> Robots { get; }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");

            foreach (IRobot robot in Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
        }

    }
}
