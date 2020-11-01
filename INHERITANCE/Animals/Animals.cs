using System;
namespace Animals
{
    public abstract class Animals
    {
        private int age = 0;

        public Animals(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age > 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public string Gender { get; set; }


        public virtual string ProduceSound()
        {
            return "";
        }
    }
}
