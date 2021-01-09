namespace Bakery.IO
{
    using System;
    using Bakery.IO.Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
