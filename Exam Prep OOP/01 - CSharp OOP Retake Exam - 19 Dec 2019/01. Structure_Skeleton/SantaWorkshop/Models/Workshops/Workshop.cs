using System.Linq;

using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (dwarf.Energy > 0 && dwarf.Instruments.Any())
            {
                IInstrument currInstrument = dwarf
                    .Instruments
                    .First();

                while (!present.IsDone() && dwarf.Energy > 0 && !currInstrument.IsBroken())
                {
                    dwarf.Work();
                    present.GetCrafted();
                    currInstrument.Use();
                }

                if (currInstrument.IsBroken())
                {
                    dwarf.Instruments.Remove(currInstrument);
                }

                if (present.IsDone())
                {
                    break;
                }
            }
        }
    }
}
