using NUnit.Framework;
using FightingArena;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorValue()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollExpIfWarriorExist()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Pesho", 10, 10);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void EnrollAddWarrier()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Pesho", 10, 10);
            Warrior fighter = new Warrior("Tosho", 10, 10);

            arena.Enroll(warrior);
            arena.Enroll(fighter);

            int expCount = 2;
            bool isWarrior = arena.Warriors
                .Any(x => x.Name == "Pesho");
            bool isAnyFighter = arena.Warriors
                .Any(x => x.Name == "Tosho");

            Assert.AreEqual(expCount, arena.Count);
            Assert.IsTrue(isWarrior);
            Assert.IsTrue(isAnyFighter);
        }


        [Test]
        [TestCase("Pesho", "Tosho")]
        public void FightShouldThrowExpIfWarriorNotExist(string fighter, string defender)
        {
            Arena arena = new Arena();

            Assert.Throws<InvalidOperationException>(() => arena.Fight(fighter, defender));

            Warrior warrior = new Warrior(fighter, 10, 10);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));

            Assert.Throws<InvalidOperationException>(() => arena.Fight(fighter, defender));
        }


        [Test]
        [TestCase("Pesho", 10, 50, 40, "Gosho", 10, 50, 40)]
        public void FightShouldWork(string fighterName, int fighterDmg, int fighterHp, int leftFighterHp, string defenderName, int defenderDmg, int defenderHp, int leftDefenderHp)
        {
            Arena arena = new Arena();

            Warrior fighter = new Warrior(fighterName, fighterDmg, fighterHp);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHp);

            arena.Enroll(fighter);
            arena.Enroll(defender);


            arena.Fight(fighter.Name, defender.Name);

            int defHp = arena.Warriors.FirstOrDefault(x => x.Name == defender.Name).HP;
            int fightHp = arena.Warriors.FirstOrDefault(x => x.Name == fighter.Name).HP;

            Assert.AreEqual(defHp, leftDefenderHp);
            Assert.AreEqual(fightHp, leftFighterHp);
        }


    }
}
