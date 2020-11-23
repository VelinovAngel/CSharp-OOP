using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using SantaWorkshop.Repositories;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Utilities.Messages;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private const int MinEnergyCraft = 50;

        private DwarfRepository dwarfs;
        private PresentRepository presents;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }


        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;

            if (dwarfType == nameof(HappyDwarf))
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == nameof(SleepyDwarf))
            {
                dwarf = new SleepyDwarf(dwarfName);
            }

            if (dwarf == null)
            {

                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }
            else
            {
                this.dwarfs.Add(dwarf);
                string result = string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
                return result;
            }


        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf currDwarf = dwarfs.FindByName(dwarfName);

            if (currDwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }
            else
            {
                IInstrument instrument = new Instrument(power);
                currDwarf.AddInstrument(instrument);
                string result = string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
                return result;
            }
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);
            presents.Add(present);
            string result = string.Format(OutputMessages.PresentAdded, presentName);
            return result;
        }

        public string CraftPresent(string presentName)
        {
            Workshop workshop = new Workshop();

            IPresent present = this.presents.FindByName(presentName);
            ICollection<IDwarf> dwarves = this.dwarfs
                .Models
                .Where(dw => dw.Energy >= MinEnergyCraft)
                .OrderByDescending(dw => dw.Energy)
                .ToList();

            if (!dwarves.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            while (dwarves.Any())
            {
                IDwarf currDwarf = dwarves
                    .First();

                workshop.Craft(present, currDwarf);

                if (!currDwarf.Instruments.Any())
                {
                    dwarves.Remove(currDwarf);
                }

                if (currDwarf.Energy == 0)
                {
                    dwarves.Remove(currDwarf);
                    this.dwarfs.Remove(currDwarf);
                }

                if (present.IsDone())
                {
                    break;
                }
            }

            string result = string.Format(present.IsDone() ? OutputMessages.PresentIsDone : OutputMessages.PresentIsNotDone , presentName);

            return result;
        }

        public string Report()
        {
            int countCraftedPresents = this.presents
                .Models
                .Count(p => p.IsDone());

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{countCraftedPresents} presents are done!")
                .AppendLine("Dwarfs info:");

            foreach (IDwarf dwarf in dwarfs.Models)
            {
                int countInstrument = dwarf
                    .Instruments
                    .Count(i => !i.IsBroken());
                sb
                    .AppendLine($"Name: {dwarf.Name}")
                    .AppendLine($"Energy: {dwarf.Energy}")
                    .AppendLine($"Instruments {countInstrument} not broken left");
            }

            return sb.ToString().TrimEnd();
                
        }
    }
}
