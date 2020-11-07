using System;
using Telephony.Interfaces;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {
        }

        public string Call(string number)
        {
            if (number.Length < 7 || number.Length > 10)
            {
                throw new ArgumentException("Invalid number!");
            }
            else
            {
                return $"Dialing... {number}";

            }

        }
    }
}
