using System;
namespace Animals
{
    public class Tomcats : Cat //(male)
    {
        private const string tomcats = "Male";
        public Tomcats(string name, int age)
            : base(name, age, tomcats)
        {

        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
