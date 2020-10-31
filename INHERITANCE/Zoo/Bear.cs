﻿using System;
namespace Zoo
{
    public class Bear : Mammal
    {
        public Bear(string name) : base(name)
        {
            this.Name = name;
        }

        public override string Name { get; set; }

    }
}