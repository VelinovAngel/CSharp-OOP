﻿using _01.Logger.Models.Contracts;

namespace _01.Logger.Models.Layouts
{
    public class SimpeLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
