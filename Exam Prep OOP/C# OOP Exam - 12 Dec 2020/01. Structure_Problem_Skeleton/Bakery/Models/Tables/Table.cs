using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using Bakery.Utilities.Messages;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {

        private readonly ICollection<IBakedFood> bakedFoodsOrderd;
        private readonly ICollection<IDrink> drinksOrderd;

        private int capacity;
        private int tableNumber;
        private int numberOfPeople;
        private decimal pricePerson;

        protected Table(int tableNumber, int capacity,decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            bakedFoodsOrderd = new List<IBakedFood>();
            drinksOrderd = new List<IDrink>();

        }

        private IReadOnlyCollection<IBakedFood> BakedFoodsOrder
            => (IReadOnlyCollection<IBakedFood>)this.bakedFoodsOrderd;

        private IReadOnlyCollection<IDrink> DrinksOrder
            => (IReadOnlyCollection<IDrink>)this.drinksOrderd;

        public int TableNumber { get => this.tableNumber; private set => this.tableNumber = value; }

        public int Capacity
        {
            get { return this.capacity; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get => this.pricePerson; private set => this.pricePerson = value; }

        //TODO
        public bool IsReserved { get; private set; }

        //ATTENCIONE
        public decimal Price
            => this.numberOfPeople * this.PricePerPerson;


        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }

        //TODO
        public void OrderFood(IBakedFood food)
        {
            bakedFoodsOrderd.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            drinksOrderd.Add(drink);
        }


        public decimal GetBill()
        {
            decimal currPrice = this.Price;
            decimal foodPrice = bakedFoodsOrderd.Sum(x=>x.Price);
            decimal drinkPrice = drinksOrderd.Sum(x=>x.Price);

            //bakedFoodsOrderd.Clear();
            //drinksOrderd.Clear();
            return foodPrice + drinkPrice + Price;
        }


        public void Clear()
        {
            drinksOrderd.Clear();
            bakedFoodsOrderd.Clear();
            IsReserved = false;
            this.NumberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb
                 .AppendLine($"Table: {this.TableNumber}")
                 .AppendLine($"Type: {this.GetType().Name}")
                 .AppendLine($"Capacity: {this.Capacity}")
                 .AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }
    }
}
