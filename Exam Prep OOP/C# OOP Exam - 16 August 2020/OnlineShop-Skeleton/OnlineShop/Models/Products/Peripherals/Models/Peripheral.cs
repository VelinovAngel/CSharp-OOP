﻿using OnlineShop.Models.Products.Models;

namespace OnlineShop.Models.Products.Peripherals.Models
{
    public class Peripheral : Product , IPeripheral
    {
        private string connectionType;

        public Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance , string connectionType)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.ConnectionType = connectionType;
        }

        public string ConnectionType { get => this.connectionType; private set => this.connectionType = value; }

        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance}. Price: {this.Price} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id}) Connection Type: {this.ConnectionType}";
        }
    }
}
