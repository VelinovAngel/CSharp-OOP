using System;
using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private const int DecreasePower = 10;
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                this.power = value > 0 ? value : 0;
            }
        }

        public void Use()
        {
            this.Power -= DecreasePower;
        }

        public bool IsBroken()
        {
            return this.Power == 0;
        }
    }
}
