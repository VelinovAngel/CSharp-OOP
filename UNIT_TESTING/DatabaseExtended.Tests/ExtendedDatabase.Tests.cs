using System;

using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private Person expectedPerson;

        [SetUp]
        public void Setup()
        {

            expectedPerson = new Person(100L, "Pesho");
            database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void ConstructorSetCurrectlyValue()
        {
            Assert.IsNotNull(expectedPerson);
            Assert.IsNotNull(database);

        }

        [Test]
        public void CheckDimArray()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(100L + i, "Pesho" + i);
            }

            int expCount = 16;

            database = new ExtendedDatabase.ExtendedDatabase(people);
            int actualCount = database.Count;

            Assert.AreEqual(expCount, actualCount);
        }

        [Test]
        public void CheckIfShouldThrowArgumentExceptionWhenCreate17Elements()
        {
            Person[] people = new Person[17];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(100L + i, "Pesho" + i);
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(people));
        }


        [Test]
        public void TestWhenAddMorePeopleIntoArray()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(100L + i, "Pesho" + i);
            }

            database = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(122133L, "Stoqn")));
        }

        [Test]
        public void AddPersonWhenHeExist()
        {
            this.database.Add(this.expectedPerson);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(this.expectedPerson));
        }

        [Test]
        [TestCase(112233L, "Pesho")]
        public void AddPersonWhenHeNameExist(long idFirstPerson, string nameFirstPerson)
        {
            this.database.Add(this.expectedPerson);


            Person newPerson = new Person(idFirstPerson, nameFirstPerson);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(newPerson));
        }

        [Test]
        [TestCase(100L, "Gosho")]
        public void AddPersonWhenHeIdExist(long idFirstPerson, string nameFirstPerson)
        {
            this.database.Add(this.expectedPerson);


            Person newPerson = new Person(idFirstPerson, nameFirstPerson);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(newPerson));
        }


        [Test]
        public void AddPersonAndCheckCount()
        {
            this.database.Add(this.expectedPerson);
            this.database.Add(new Person(10L, "Gosho"));

            int expCount = 2;
            int currCount = database.Count;

            Assert.AreEqual(expCount, currCount);
        }

        [Test]
        public void RemoveMothodWhenIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void TestRemoveMethodIfDecreaseCount()
        {
            this.database.Add(this.expectedPerson);
            this.database.Add(new Person(12390L, "Gosho"));
            this.database.Remove();
            int expCount = 1;
            int actualCount = database.Count;

            Assert.AreEqual(expCount, actualCount);
        }
    }
}

