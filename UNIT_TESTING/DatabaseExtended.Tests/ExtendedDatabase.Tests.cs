//using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person[] people;
        private ExtendedDatabase database;
        //private Person expectedPerson;

        [SetUp]
        public void Setup()
        {
            people = new Person[]
            { new Person(0,"Pesho"),
              new Person (1,"Misho"),
              new Person (2,"Gosho"),
              new Person (3,"Mimi"),
              new Person (4,"Rosana"),
              new Person(5,"Peshito"),
              new Person (6,"Mishto"),
              new Person (7,"Goshko"),
              new Person (8,"Mimito"),
              new Person (9, "Roxana"),
              new Person(10,"Pepi"),
              new Person (11,"Mishko"),
              new Person (12,"Gosheto"),
              new Person (13,"Mitko"),
              new Person (14, "Roximira"),
              new Person (15, "Nikolina"),
            };

            database = new ExtendedDatabase(people);
        }

        [Test]
        public void ConstructorThrowsExeptionIfPeopleAreNotExactly16()
        {
            people = new Person[]
            {
              new Person(12478,"Pesho"),
              new Person (32092,"Misho"),
              new Person (43589,"Gosho"),
              new Person (49109,"Mimi"),
              new Person (9820989,"Rosana"),
              new Person(12345,"Peshito"),
              new Person (32098,"Mishto"),
              new Person (43356,"Goshko"),
              new Person (492098,"Mimito"),
              new Person (9836749, "Roxana"),
              new Person(123490,"Pepi"),
              new Person (32078,"Mishko"),
              new Person (433590,"Gosheto"),
              new Person (492678,"Mitko"),
              new Person (9836745, "Roximira"),
              new Person (8963790, "Nikolina"),
              new Person (432516, "Maxi")
            };

            Assert.That(() => new ExtendedDatabase(people), Throws.ArgumentException);
        }

        [Test]
        public void AddOperationShouldThrowExeptionIfCountIsMoreThan16()
        {
            Person newPerson = new Person(236187, "Martina");
            Assert.That(() => database.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void
      AddOperationThrowsExeptionIfThereIsAlreadyPersonWithThatName()
        {
            Person newPerson = new Person(325468, "Roximira");
            database.Remove();

            Assert.That(() => database.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void AddOperationThrowsExeptionWhenAddingPersonWithIdThatAlreadyIsAssignToExistingPersonInDatabase()
        {
            Person newPerson = new Person(10, "Miteto");
            database.Remove();

            Assert.That(() => database.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveOperationSouldRemoveTheLastElementFromTheCollection()
        {
            database.Remove();

            int expectedCount = 15;
            int actualCount = database.Count;

            //The last person's ID is 15, if the program can not find it 
            //that means the last one is removed
            Assert.That(() => database.FindById(15), Throws.InvalidOperationException);
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemovingElementFromEmptyDatabaseThrowsExeption()
        {
            Assert.That(() => new ExtendedDatabase().Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindPersonByNameThrowsExeptionWhenNameIsNull(string expectedValue)
        {
            Assert.That(() => database.FindByUsername(expectedValue), Throws.ArgumentNullException);
        }

        [Test]
        public void FindPersonByNameThrowsExeptionWhenThereIsNoSuchPersonInDatabase()
        {
            string expName = "Magda";

            Assert.That(() => database.FindByUsername(expName), Throws.InvalidOperationException);
        }

        [Test]
        public void FindPersonByNameInDatabase()
        {
            string expectedName = "Pesho";
            Person currentPerson = database.FindByUsername("Pesho");

            string actualName = currentPerson.UserName;
            Assert.AreEqual(expectedName, actualName);
        }


        [Test]
        public void ArgumentsAreCaseSensitiveInFindPersonByName()
        {
            Person findPerson = database.FindById(10);
            string name = findPerson.UserName.ToLower();

            Assert.That(() => database.FindByUsername(name), Throws.InvalidOperationException);
        }

        [Test]
        public void FindPersonByIdThrowsExeptionWhenThereIsNoPersonWithThatId()
        {
            long id = 18;

            Assert.That(() => database.FindById(id), Throws.InvalidOperationException);
        }



        [Test]
        public void FindPersonById()
        {
            long expectedId = 0;
            Person actualPerson = database.FindById(0);

            long actualId = actualPerson.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void FindPersonByIdThrowsExeptionWhenIsNegativeId()
        {
            long id = -1;

            Assert.Throws<System.ArgumentOutOfRangeException>(() => database.FindById(id));
        }
    }
}

