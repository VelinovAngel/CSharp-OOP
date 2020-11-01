using System;
using System.Text;

namespace Animals
{
    public abstract class Animals
    {
        private string name;
        private int age;
        private string gender;

        public Animals(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }


        public string Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }


        public abstract string ProduceSound();


        //public override string ToString()
        //{
        //    StringBuilder builder = new StringBuilder();

        //    builder.AppendLine(this.GetType().Name)
        //        .AppendLine($"{this.Name} {this.Age} {this.Gender.ToString()}")
        //        .Append($"{this.ProduceSound()}");

        //    return builder.ToString().TrimEnd();
        //}
    }
}
