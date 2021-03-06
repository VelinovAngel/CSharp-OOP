using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(Enumerable.Range(1, 16).ToArray());
        }

        [Test]
        public void ConstructorShouldReturnCorrectlyValue()
        {
            Assert.IsNotNull(this.database);
            Assert.AreEqual(16, this.database.Count);
        }

        [Test]
        public void CheckIfCountIsCorretly16Elements()
        {
            Assert.Throws<InvalidOperationException>(() => new Database.Database(Enumerable.Range(1, 17).ToArray()));
        }

        [Test]
        public void CheckIfRemoveLastElement()
        {
            this.database.Remove();
            int expectedValue = 15;
            Assert.AreEqual(expectedValue, this.database.Count);
        }

        [Test]
        public void CheckIfWhenCountIsZeroShouldThrowException()
        {
            Database.Database databaseExp = new Database.Database();
            Assert.Throws<InvalidOperationException>(() => databaseExp.Remove());
        }

        [Test]
        public void CheckIfFatchReturnCurrectlyResult()
        {
            int[] expArray = Enumerable.Range(1, 16).ToArray();

            int[] returnArray = this.database.Fetch();

            Assert.AreEqual(expArray, returnArray);
        }


    }
}