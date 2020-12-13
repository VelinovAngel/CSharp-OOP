using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            item = new Item("A1", "THE BEST");
            bankVault = new BankVault();
        }

        [Test]
        public void CheckIfConstructorItemReturnCorrectlyValue()
        {
            Assert.NotNull(this.item);
        }

        [Test]
        public void CheckIfConstructorBankReturnCorrectlyValue()
        {
            Assert.NotNull(this.bankVault);
        }

        [Test]
        public void CheckIfConstructorBankReturnCorrectlyValueSecond()
        {
            Item item = null;

            string value = "A1";

            Assert.AreEqual(this.bankVault.VaultCells[value] , item);
            
        }

        [Test]
        public void AddMethodExcep()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("H1", this.item));
            bankVault.AddItem("A1", this.item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", this.item));
        }
        [Test]
        public void AddMethodInvalid()
        {
            Item item = new Item("Angel", "Apple");
            bankVault.AddItem("A3", item);

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));

        }

        [Test]
        public void Remove()
        {
            Item item = new Item("Angel", "Apple");
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("H1", item));
            
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("H1", item));
            //bankVault.AddItem("A1", this.item);
            //Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", this.item));
        }

        [Test]
        public void ChechIfRemovedItem()
        {
            Item itemADD = new Item("Angel", "Apple");
            bankVault.AddItem("A1", itemADD);
            bankVault.RemoveItem("A1",itemADD);

            Item item = null;
            Assert.AreEqual(bankVault.VaultCells["A1"], item);
        }
    }
}