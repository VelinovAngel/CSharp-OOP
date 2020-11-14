using System;
using System.Collections.Generic;

using _03.Raiding.Models;

namespace _03.Raiding.Core
{
    public class Engine
    {
        private ICollection<BaseHero> heroes;

        public Engine()
        {
            heroes =new List<BaseHero>();

        }
    }
}
