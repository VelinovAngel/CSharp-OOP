using System;
namespace Animals
{
    public class Tomcat : Cat //(male)
    {
        private const string tomcats = "Male";
        public Tomcat(string name, int age)
            : base(name, age, tomcats)
        {

        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
