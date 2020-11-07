using System;
using System.Linq;
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
                throw new ArgumentException("Invalid URL!");
            }
            else
            {
                return $"Browsing: {url}!";

            }

        }

        public string Call(string number)
        {
            if (number.Length < 7 || number.Length > 10)
            {
                throw new ArgumentException("Invalid number!");
            }
            else if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Invalid number!");
            }
            else if (!number.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }
            else
            {
                return $"Calling... {number}";
            }

        }
    }
}
