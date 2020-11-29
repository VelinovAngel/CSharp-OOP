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
            {
              new Person(0,"0"),
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
            int expRange = 16;
            Assert.AreEqual(expRange, this.extendedDatabase.Count);

            Assert.IsNotNull(this.people);
        }

        [Test]
        public void CheckIfAddRangeShouldThrowInvalidOperationExp()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(this.person));
        }
        [Test]
        public void CheckIfAddRangeShouldThrowArgumentExp()
        {
            people = new ExtendedDatabase.Person[]
            {
              new Person(0,"0"),
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
              new Person (16, "16"),
            };

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void CheckIfAlreadyUserExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(0, "15")));
        }

        [Test]
        public void CheckIfAlreadyUserWithSomeIDExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(15, null)));
        }

        [Test]
        public void CheckIfRemoveReturnExaclyValue()
        {
            ExtendedDatabase.Person[] person = new ExtendedDatabase.Person[0];

            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(person);


            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }

        [Test]
        public void CheckIfRemoveReturnExaclyCountValueAfterRemove()
        {
            people = new ExtendedDatabase.Person[]
            {
              new Person(0,"0"),
              new Person (1,"1"),
            };

            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);
            extendedDatabase.Remove();
            int expCount = 1;

            Assert.AreEqual(expCount, extendedDatabase
                .Count);
        }

        [Test]
        public void IfUserIsPresentUsernameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(null));
        }

        [Test]
        public void IfUserIsNotPresentUsername()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindByUsername("Pesho"));
        }

        [Test]
        public void IfUserIsPresentUsername()
        {
            people = new ExtendedDatabase.Person[]
           {
              new Person(123120,"Tosho"),
              new Person (112321,"Gosho"),
           };

            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);


            //Person ExpPerson = new Person(123120, "Pesho");

            Person currPerson = extendedDatabase
                .FindByUsername("Pesho");

            Assert.AreEqual(this.person, currPerson);
        }

        [Test]
        public void IfUserIsPresenIDIsNull()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendedDatabase.FindById(-1));
        }

        [Test]
        public void IfUserIsNotPresenID()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindById(123123));
        }

        public void IfUserIsPresentUsernameID()
        {
            people = new ExtendedDatabase.Person[]
           {
              new Person(123120,"Pesho"),
              new Person (112321,"Gosho"),
           };

            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);


            Person ExpPerson = new Person(123120, "Pesho");

            Person currPerson = extendedDatabase
                .FindById(123120);

            Assert.Equals(ExpPerson, currPerson);
        }
    }
}