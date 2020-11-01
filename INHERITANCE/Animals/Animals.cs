using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animals
    {
        private int age;
        private string name;
        private Gender gender;


        public Animals(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
            
        }

        public int Age
        {
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
            set
            {
                Gender gender;
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) || !Enum.TryParse<Gender>(value, out gender))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = gender;
            }
        }


        public virtual string ProduceSound()
        {
            return null;
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(this.GetType().Name)
                .AppendLine($"{this.name} {this.age} {this.gender.ToString()}")
                .Append($"{this.ProduceSound()}");

            return builder.ToString();
        }
    }
}
