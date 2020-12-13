using System;
using System.Collections.Generic;
using System.Linq;

using OnlineShop.Common.Enums;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.ProductModels.ComputersModels;
using OnlineShop.Models.Products.ProductModels.ComponentsModels;
using OnlineShop.Models.Products.ProductModels.PeripheralModels;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();

        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (!Enum.TryParse(computerType, out ComputerType pcType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidComputerType));
            }

            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = CreateComputerType(id, manufacturer, model, price, pcType);

            this.computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddComponent(int computerId, int id, string component, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!Enum.TryParse(component, out ComponentType componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidComponentType));
            }

            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent currComponent = CreateComponent(id, manufacturer, model, price, overallPerformance, generation, componentType);

            IComputer computer = this.computers
              .FirstOrDefault(c => c.Id == computerId);

            computer.AddComponent(currComponent);

            components.Add(currComponent);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }



        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!Enum.TryParse(peripheralType, out PeripheralType peripheralComputerType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidPeripheralType));
            }

            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            NotExistingComputer(computer);

            IPeripheral peripheral = CreatePeripherial(id, manufacturer, model, price, overallPerformance, connectionType, peripheralComputerType);

            peripherals.Add(peripheral);
            computer.AddPeripheral(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);

        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            NotExistingComputer(computer);

            IComponent component = computer.RemoveComponent(componentType);

            components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }


        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            NotExistingComputer(computer);

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);

            peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = computers
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault(x => x.Price <= budget);


            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = computers
            .FirstOrDefault(x => x.Id == id);

            NotExistingComputer(computer);

            string result = computer.ToString();
            //if (computer == null)
            //{

            //}
            computers.Remove(computer);

            return result;
        }

        public string GetComputerData(int id)
        {
            IComputer computer = computers
               .FirstOrDefault(x => x.Id == id);
            NotExistingComputer(computer);

            return computer.ToString();
        }


        private static void NotExistingComputer(IComputer computer)
        {
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }

        private static IComputer CreateComputerType(int id, string manufacturer, string model, decimal price, ComputerType pcType)
        {
            return pcType switch
            {
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),
            };
        }

        private static IComponent CreateComponent(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation, ComponentType componentType)
        {
            IComponent newComponent = componentType switch
            {
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
            };

            return newComponent;
        }

        private static IPeripheral CreatePeripherial(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType, PeripheralType peripheralComputerType)
        {
            IPeripheral peripheral = peripheralComputerType switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance,
                    connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance,
                    connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance,
                    connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
            };

            return peripheral;
        }

    }
}
