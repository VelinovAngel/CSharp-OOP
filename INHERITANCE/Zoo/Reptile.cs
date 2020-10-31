using System;
namespace Zoo
{
    public class Reptile : Animal
    {
        public Reptile(string name) : base(name)
        {
            this.Name = name;
        }

        public override string Name { get; set; }
    }
}
