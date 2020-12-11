﻿using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.ProductModels.PeripheralModels
{
    public abstract class Peripheral : Product, IPeripheral
    {
        public Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.ConnectionType = connectionType;
        }

        public string ConnectionType { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $" Connection Type: {this.ConnectionType}";
        }
    }
}
