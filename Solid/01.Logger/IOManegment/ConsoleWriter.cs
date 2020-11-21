using System;
using _01.Logger.IOManegment.Contracts;

namespace _01.Logger.IOManegment
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
            => Console.Write(text);

        public void WriteLine(string text)
            => Console.WriteLine(text);
    }
}
