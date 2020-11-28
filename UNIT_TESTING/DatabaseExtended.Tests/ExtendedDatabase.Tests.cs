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
        private ExtendedDatabase.Person[] people;

        [SetUp]
        public void Setup()
        {
            people = new ExtendedDatabase.Person[]
           { new Person(0,"0"),
              new Person (1,"1"),
              new Person (2,"2"),
              new Person (3,"3"),
              new Person (4,"4"),
              new Person(5,"5"),
              new Person (6,"6"),
              new Person (7,"7"),
              new Person (8,"8"),
              new Person (9, "9"),
              new Person(10,"10"),
              new Person (11,"11"),
              new Person (12,"12"),
              new Person (13,"13"),
              new Person (14, "14"),
              new Person (15, "15"),
           };

            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);
            this.person = new ExtendedDatabase.Person(100, "Tosho");
        }

        [Test]
        public void ConstructorShouldReturnCorrectlyValue()
        {
            Assert.IsNotNull(this.extendedDatabase);
            Assert.AreEqual(16, this.extendedDatabase.Count);

            Assert.IsNotNull(this.people);
        }

        [Test]
        public void CheckIfAddRangeShouldThrowExp()
        {
           Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(this.person));
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