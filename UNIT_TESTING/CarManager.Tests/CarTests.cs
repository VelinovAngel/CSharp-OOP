using NUnit.Framework;
using CarManager;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("make", "golf", 10, 100);
        }

        [Test]
        public void ConstructorShouldReturnCorrectlyValue()
        {
            Assert.IsNotNull(this.car);
        }

        [Test]
        public void MakeShouldThrowExcpWhenIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new Car("", "golf", 10, 100));
        }

        [Test]
        public void ModelShouldThrowExcpWhenIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "", 10, 100));
        }

        [Test]
        public void TestIfFuelConsumptionIsNegativOrZero()
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "golf", 0, 100));
        }

        [Test]
        public void TestIfFuelAmountIsNegativOrZero()
        {
            double exp = 0;
            Assert.AreEqual(exp, this.car.FuelAmount);
        }

        [Test]
        public void TestIfFuelCapacityIsNegativOrZero()
        {
            
            Assert.Throws<ArgumentException>(() => new Car("make", "golf", 10, 0));
        }

        [Test]
        public void RefulMethodShouldThrowExp()
        {

            Assert.Throws<ArgumentException>(() => this.car.Refuel(-1));
        }

        [Test]
        public void CheckIfFuelAmountIsEqualToFuelReful()
        {
            this.car.Refuel(1);
            Assert.AreEqual(1, this.car.FuelAmount);
        }

        [Test]
        public void CheckIfFuelCapcityIsEqualToFuelAmount()
        {
            var currCar = new Car("make", "golf", 10, 1);
            currCar.Refuel(1);
            Assert.AreEqual(currCar.FuelAmount, currCar.FuelCapacity);
        }

        [Test]
        public void CheckDriveShouldThrowExp()
        {    
            this.car.Refuel(1);

            Assert.Throws<InvalidOperationException>(() => this.car.Drive(1000));
        }


        [Test]
        public void CheckFuelAmountAfterDrive()
        {
            //fuelConsumption = 10;
            double exp = 9.0d;
            this.car.Refuel(10);
            this.car.Drive(10);

            Assert.AreEqual(exp, car.FuelAmount);
        }


    }
}