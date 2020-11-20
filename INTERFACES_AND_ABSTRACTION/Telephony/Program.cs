using System;

using Telephony.GlobalConstans;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split();

            string[] urls = Console.ReadLine()
                .Split();

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    if (numbers[i].Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(numbers[i]));

                    }
                    else if (numbers[i].Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(numbers[i]));
                    }
                    else
                    {
                        throw new ArgumentException(Constant.InvalidNumberExp);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }

            for (int i = 0; i < urls.Length; i++)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(urls[i]));

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
