﻿using System;
namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private double defaultFuelConsumption = 8;
        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public virtual double DefaultFuelConsumption
        {
            get
            {
                return defaultFuelConsumption;
            }
            set
            {
                defaultFuelConsumption = value;
            }
        }
    }
}
