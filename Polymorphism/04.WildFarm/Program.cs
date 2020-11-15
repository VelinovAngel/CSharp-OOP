using _04.WildFarm.Core;
using _04.WildFarm.Core.Interface;

namespace _04.WildFarm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
