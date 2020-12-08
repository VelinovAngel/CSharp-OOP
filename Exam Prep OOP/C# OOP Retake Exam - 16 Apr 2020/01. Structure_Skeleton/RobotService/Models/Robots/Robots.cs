using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Robots
{
    public abstract class Robots : IRobot
    {
        private int happiness;
        private int energy;
        private string owner = "Service";
        private bool isBought = false;
        private bool isChipped = false;
        private bool isChecked = false;


        public string Name { get; }

        public int Happiness
        {
            get
            {
                return this.happiness;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }
                this.happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public bool IsBought { get => this.isBought; set => value = this.isBought; }

        public bool IsChipped { get => this.isChipped; set => value = this.isChipped; }

        public bool IsChecked { get => this.isChecked; set => value = this.isChecked; }
    }
}
