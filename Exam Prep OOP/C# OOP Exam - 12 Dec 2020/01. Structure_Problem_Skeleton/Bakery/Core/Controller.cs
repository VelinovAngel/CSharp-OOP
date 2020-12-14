using System.Text;
using System.Linq;
using System.Collections.Generic;

using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IBakedFood> foods;
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<ITable> tables;
        private readonly List<decimal> allSum;

        private IBakedFood food;
        private IDrink drink;
        private ITable table;


        public Controller()
        {
            foods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
            allSum = new List<decimal>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            drink = null;

            if (type == nameof(Tea))
            {
                drink = new Tea(name, portion, brand);
            }
            if (type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }

            if (drink != null)
            {
                drinks.Add(drink);
            }
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            food = null;
            if (type == nameof(Bread))
            {
                food = new Bread(name, price);
            }
            if (type == nameof(Cake))
            {
                food = new Bread(name, price);
            }

            if (food != null)
            {
                foods.Add(food);
            }

            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            table = null;
            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber, capacity);
            }
            if (type == nameof(OutsideTable))
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            if (table != null)
            {
                tables.Add(table);
            }
            return $"Added table number {tableNumber} in the bakery";
        }


        public string ReserveTable(int numberOfPeople)
        {
            var currTable = tables
                .Where(x => x.Capacity > numberOfPeople)
                .FirstOrDefault(x => x.IsReserved == false);

            if (currTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                currTable.Reserve(numberOfPeople);
                return $"Table {currTable.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }



        public string OrderFood(int tableNumber, string foodName)
        {
            var currTableNum = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var currTableFoodName = foods.FirstOrDefault(x => x.Name == foodName);

            if (currTableNum == null)
            {
                return $"Could not find table {tableNumber}";
            }

            if (currTableFoodName == null)
            {
                return $"No {foodName} in the menu";
            }

            currTableNum.OrderFood(currTableFoodName);
            return $"Table {currTableNum.TableNumber} ordered {currTableFoodName.Name}";
        }


        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var currTableNum = tables
                .FirstOrDefault(x => x.TableNumber == tableNumber);
            var currDrinkName = drinks
                .FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (currTableNum == null)
            {
                return $"Could not find table {tableNumber}";
            }


            if (currDrinkName == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            currTableNum.OrderDrink(currDrinkName);
            return $"Table {currTableNum.TableNumber} ordered {currDrinkName.Name} {currDrinkName.Brand}";

        }

        public string LeaveTable(int tableNumber)
        {
            var currTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            decimal bill = currTable.GetBill();

            allSum.Add(bill);
           currTable.Clear();
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }


        public string GetFreeTablesInfo()
        {
            var currTables = tables.Where(x => x.IsReserved == false);

            StringBuilder sb = new StringBuilder();

            foreach (var item in currTables)
            {
                sb.AppendLine(item.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            decimal price = allSum.Sum();
                
            return $"Total income: {price:f2}lv";
        }

    }
}
