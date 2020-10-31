using System;
namespace Zoo
{
    public class Snake : Reptile
    {
        public Snake(string name) : base(name)
        {
            this.Name = name;
        }

        public override string Name { get; set; }
    }
}
