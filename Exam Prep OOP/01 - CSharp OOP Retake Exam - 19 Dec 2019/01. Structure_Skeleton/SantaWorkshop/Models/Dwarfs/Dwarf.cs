using System;
using System.Collections.Generic;

using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private const int DecreaseEnergy = 10;

        private string name;
        private int enegry;

        private Dwarf()
        {
            this.Instruments = new List<IInstrument>();
        }

        protected Dwarf(string name, int energy)
            :this()
        {
            this.Name = name;
            this.Energy = energy;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.enegry;
            }
            protected set
            {
                this.enegry = value > 0 ? value : 0;
            }
        }

        public ICollection<IInstrument> Instruments { get; }

        public virtual void Work()
        {
            this.Energy -= DecreaseEnergy;
        }

        public void AddInstrument(IInstrument instrument)
        {
            this.Instruments.Add(instrument);
        }
    }
}
