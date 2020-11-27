using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;


        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(new int[16]);
        }

        [Test]
        public void ConstructorShouldReturnCorrectlyValue()
        {
            Assert.IsNotNull(this.database);
        }
    }
}