using System;

namespace _01.ClassBoxData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());



            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine(box);

            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }

            //Box box = new Box(length, width, height);


        }

    }
}
