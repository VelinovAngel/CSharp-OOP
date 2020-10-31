using System;
namespace Zoo
{
    public class Mammal : Animal
    {
        public Mammal(string name) : base(name)
        {
            this.Name = name;
        }

        public override string Name { get; set; }
    }
}
