using System;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person("Gosho", -1.5m);

            }
            catch (ArgumentException argex)
            {
                Console.WriteLine(argex.Message);
            }
        }
    }
}
