using System;
using System.Collections.Generic;

using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Models;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers.Models
{
    public abstract class Computer : Product, IComputer
    {
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
        }

        public IReadOnlyCollection<IComponent> Components => throw new NotImplementedException();

        public IReadOnlyCollection<IPeripheral> Peripherals => throw new NotImplementedException();



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
