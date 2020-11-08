using System;
using Telephony.GlobalConstans;
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
                throw new ArgumentException(Constant.InvalidNumberExp);
            }
            else
            {
                return $"Dialing... {number}";

            }

        }
    }
}
