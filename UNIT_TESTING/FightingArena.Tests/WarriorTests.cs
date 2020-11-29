using System;

using NUnit.Framework;
using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Pesho", 10, 10)]
        [TestCase("Tosho", 20, 20)]
        [TestCase("Ivan", 20, 0)]
        public void WarriorConstructorSetCorrectlyValue(string name, int dmg, int hp)
        {
            Warrior warrior = new Warrior(name, dmg, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(dmg, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase("", 10, 20)]
        [TestCase(" ", 50, 60)]
        [TestCase(null, 80, 90)]
        public void WarriorConstructorShouldThrowExpIfInvalidName(string name, int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, dmg, hp));
        }

        [Test]
        [TestCase("Gosho", 0, 60)]
        [TestCase("Tosho", -10, 90)]
        public void WarriorConstructorShouldThrowExpIfInvalidDmg(string name, int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, dmg, hp));
        }

        [Test]
        [TestCase("Pesho", 10, -1)]
        public void WarriorConstructorShouldThrowExpIfNegativeHp(string name, int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, dmg, hp));
        }

        [Test]
        [TestCase("Pesho", 10, 10, "Gosho", 10, 10)]
        [TestCase("Pesho", 10, 100, "Gosho", 10, 10)]
        [TestCase("Pesho", 10, 50, "Gosho", 100, 50)]
        public void WarriorAttackShouldThrowExpIfHpInvalid(string fighterName, int fighterDmg, int fighterHp, string defenderName, int defenderDmg, int defenderHp)
        {
            Warrior fighter = new Warrior(fighterName, fighterDmg, fighterHp);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHp);

            Assert.Throws<InvalidOperationException>(() => fighter.Attack(defender));
        }

        [Test]
        [TestCase("Pesho", 10, 50, 40, "Gosho", 10, 50, 40)]
        [TestCase("Pesho", 20, 100, 90, "Gosho", 10, 70, 50)]
        public void WarriorAttackWhenDecreaseHP(string fighterName, int fighterDmg, int fighterHp, int fighterHpLeft, string defenderName, int defenderDmg, int defenderHp, int defHpLeft)
        {
            Warrior fighter = new Warrior(fighterName, fighterDmg, fighterHp);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHp);

            fighter.Attack(defender);

            int expFighterHp = fighterHpLeft;
            int expDefHp = defHpLeft;

            Assert.AreEqual(expFighterHp, fighter.HP);
            Assert.AreEqual(expDefHp, defender.HP);
        }


    }
}