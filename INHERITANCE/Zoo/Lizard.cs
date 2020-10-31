using System;
namespace Zoo
{
    public class Lizard : Reptile
    {
        public Lizard(string name) : base(name)
        {
            this.Name = name;
        }

        public override string Name { get; set; }
    }
}
