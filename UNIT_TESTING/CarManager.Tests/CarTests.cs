using NUnit.Framework;
using System;
using CarManager;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("VW", "golf", 10, 100);
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
            Assert.Throws<ArgumentException>(() => new Car("VW", "", 10, 100));
        }

        [Test]
        public void TestIfFuelConsumptionIsNegativOrZero()
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", "golf", -3, 100));
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
            
            Assert.Throws<ArgumentException>(() => new Car("VW", "golf", 10, 0));
        }

        [Test]
        public void RefulMethodShouldThrowExp()
        {

            Assert.Throws<ArgumentException>(() => this.car.Refuel(-1));
        }

        [Test]
        public void TestRefuelingCorrectly()
        {
            this.car.Refuel(15);
            int expFuel = 15;

            Assert.AreEqual(expFuel, this.car.FuelAmount);
        }

        [Test]
        public void TestRefuelWithZero()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(0);
            });
        }

        [Test]
        public void TestRefuelBelowZero()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(-3);
            });
        }

        [Test]
        public void TestIfRefuelMoreThanCapacity()
        {
            this.car.Refuel(350);
            int expectedFuel = 100;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
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