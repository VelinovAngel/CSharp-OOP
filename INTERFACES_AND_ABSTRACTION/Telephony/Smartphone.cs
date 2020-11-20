using System;
using System.Linq;
using Telephony.GlobalConstans;
using Telephony.Interfaces;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseble
    {

        public Smartphone()
        {
        }

        public string Browse(string url)
        {
            //[] currUrl = url.ToCharArray();
            if (url.Any(x => char.IsDigit(x)) || string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException(Constant.InvalidUrlExp);
            }
            else
            {
                return $"Browsing: {url}!";

            }
        }

        public string Call(string number)
        {
            if (string.IsNullOrWhiteSpace(number) || (!number.All(x => char.IsDigit(x))))
            {
                throw new ArgumentException(Constant.InvalidNumberExp);
            }
            else
            {
                return $"Calling... {number}";
            }

        }
    }
}
