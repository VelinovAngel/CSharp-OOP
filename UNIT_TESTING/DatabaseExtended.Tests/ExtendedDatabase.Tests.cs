using System;
using System.Linq;
using NUnit.Framework;
using ExtendedDatabase;

namespace Tests
{
    public class ExtendedDatabaseTest
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;
        private ExtendedDatabase.Person person;

        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(new ExtendedDatabase.Person[16]);

            this.person = new ExtendedDatabase.Person(10, "Pesho");
        }

        [Test]
        public void ConstructorShouldReturnCorrectlyValue()
        {
            Assert.IsNotNull(this.extendedDatabase);
            Assert.AreEqual(16, this.extendedDatabase.Count);

            Assert.IsNotNull(this.person);
        }

        [Test]
        public void CheckIfAddRangeShouldThrowExp()
        {
           Assert.Throws<ArgumentException>(() => this.extendedDatabase.Add(this.person));
        }

        //[Test]
        //public void CheckIfRemoveLastElement()
        //{
        //    this.Remove();
        //    int expectedValue = 15;
        //    Assert.AreEqual(expectedValue, this.Count);
        //}

        //[Test]
        //public void CheckIfWhenCountIsZeroShouldThrowException()
        //{
        //    ExtendedDatabaseExp = new ExtendedDatabase.ExtendedDatabase();
        //    Assert.Throws<InvalidOperationException>(() => ExtendedDatabaseExp.Remove());
        //}

        //[Test]
        //public void CheckIfFatchReturnCurrectlyResult()
        //{
        //    int[] expArray = Enumerable.Range(1, 16).ToArray();

        //    int[] returnArray = this.Fetch();

        //    Assert.AreEqual(expArray, returnArray);
        //}


    }
}