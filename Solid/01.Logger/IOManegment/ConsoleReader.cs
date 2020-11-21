using _01.Logger.IOManegment.Contracts;

namespace _01.Logger.IOManegment
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        => System.Console.ReadLine();
    }
}
