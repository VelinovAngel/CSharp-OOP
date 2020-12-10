﻿using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Models;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers.Models
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components
            => (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals
               => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                return base.OverallPerformance + components.Average(x => x.OverallPerformance);
            }
        }

        public override decimal Price
            => base.Price +
            this.Peripherals.Sum(x => x.Price) +
            this.Components.Sum(x => x.Price);


        public void AddComponent(IComponent component)
        {
            throw new NotImplementedException();
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            throw new NotImplementedException();
        }

        public IComponent RemoveComponent(string componentType)
        {
            throw new NotImplementedException();
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            throw new NotImplementedException();
        }
    }

}
