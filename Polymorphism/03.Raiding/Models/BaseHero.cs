﻿using System;
namespace _03.Raiding.Models
{
    public abstract class BaseHero
    {

        protected BaseHero(string name )
        {
            this.Name = name;
        }

        public string Name { get;}

        public int Power { get;}

        public abstract string CastAbility();
       
        
    }
}
