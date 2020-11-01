using System;
using System.Text;

namespace Animals
{
    public abstract class Animals
    {
       

        public Animals(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }

        public int Age { get; set; }


        public string Gender { get; set; }


        public abstract string ProduceSound();


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(this.GetType().Name)
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .Append($"{this.ProduceSound()}");

            return builder.ToString().TrimEnd();
        }
    }
}
