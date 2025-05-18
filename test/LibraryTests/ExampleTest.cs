using NUnit.Framework;
using Library;
using Library.Elementos;


namespace Game.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        [Test]
        public void Wizard_InitialStats_InRange()
        {
            var w = new Wizard("Gandalf");
            Assert.That(w.CurrentHealth, Is.InRange(70, 100));
            Assert.AreEqual(10, w.Ataque);
            Assert.AreEqual(5, w.Defensa);
        }

        [Test]
        public void Elve_StaticSape_SharedValueInRange()
        {
            // Elve.sape is initialized once per AppDomain
            var e1 = new Elve("Legolas");
            var e2 = new Elve("Thranduil");
            int s1 = Elve.sape;
            int s2 = Elve.sape;
            Assert.AreEqual(s1, s2);
            Assert.That(s1, Is.InRange(10, 79));
        }

        [Test]
        public void Dwarve_InitialStats_InRange()
        {
            var d = new Dwarve("Gimli");
            Assert.That(d.CurrentHealth, Is.InRange(70, 100));
            Assert.AreEqual(10, d.Ataque);
            Assert.AreEqual(5, d.Defensa);
        }
    }

    [TestFixture]
    public class DefensiveItemsTests
    {
        [Test]
        public void Shield_IncreasesDefenseBy5()
        {
            var p = new Wizard("Test");
            p.Defensa = 0;
            DefensiveItems.Shield(p);
            Assert.AreEqual(5, p.Defensa);
        }

        [Test]
        public void Armor_IncreasesDefenseBy5()
        {
            var p = new Wizard("Test");
            p.Defensa = 2;
            DefensiveItems.Armor(p);
            Assert.AreEqual(7, p.Defensa);
        }

        [Test]
        public void Helmet_IncreasesDefenseBy3()
        {
            var p = new Wizard("Test");
            p.Defensa = 4;
            DefensiveItems.Helmet(p);
            Assert.AreEqual(7, p.Defensa);
        }
    }

    [TestFixture]
    public class OfensiveItemsTests
    {
        [Test]
        public void Sword_IncreasesAttackBy5()
        {
            var p = new Wizard("Test");
            p.Ataque = 0;
            OfensiveItems.Sword(p);
            Assert.AreEqual(5, p.Ataque);
        }

        [Test]
        public void MagicStaff_IncreasesAttackBy5()
        {
            var p = new Wizard("Test");
            p.Ataque = 3;
            OfensiveItems.MagicStaff(p);
            Assert.AreEqual(8, p.Ataque);
        }

        [Test]
        public void Axe_IncreasesAttackBy5()
        {
            var p = new Wizard("Test");
            p.Ataque = 7;
            OfensiveItems.Axe(p);
            Assert.AreEqual(12, p.Ataque);
        }
    }

    [TestFixture]
    public class SpecialItemsTests
    {
        [Test]
        public void SpellBook_Wizard_ReturnsTrueAnd_IncreasesAttackBy10()
        {
            var w = new Wizard("Gandalf");
            w.Ataque = 10;
            bool result = SpecialItems.SpellBook(w);
            Assert.IsTrue(result);
            Assert.AreEqual(20, w.Ataque);
        }

        [Test]
        public void SpellBook_NonWizard_ReturnsFalse_NoChange()
        {
            var e = new Elve("Legolas");
            e.Ataque = 10;
            bool result = SpecialItems.SpellBook(e);
            Assert.IsFalse(result);
            Assert.AreEqual(10, e.Ataque);
        }
    }

    [TestFixture]
    public class ActionsTests
    {
        [Test]
        public void Attack_DefLessThanAtq_DamageEqualsAtqMinusDef()
        {
            var attacker = new Wizard("Att");
            var defender = new Wizard("Def");
            attacker.Ataque = 15;
            defender.Defensa = 5;
            defender.CurrentHealth = 100;

            Actions.Attack(attacker, defender);

            Assert.AreEqual(90, defender.CurrentHealth);
        }

        [Test]
        public void Attack_DefGreaterThanAtq_DamageIsOne()
        {
            var attacker = new Wizard("Att");
            var defender = new Wizard("Def");
            attacker.Ataque = 5;
            defender.Defensa = 10;
            defender.CurrentHealth = 50;

            Actions.Attack(attacker, defender);

            Assert.AreEqual(49, defender.CurrentHealth);
        }

        [Test]
        public void Attack_DefEqualToAtq_DamageIsOne()
        {
            var attacker = new Wizard("Att");
            var defender = new Wizard("Def");
            attacker.Ataque = 10;
            defender.Defensa = 10;
            defender.CurrentHealth = 30;

            Actions.Attack(attacker, defender);

            Assert.AreEqual(29, defender.CurrentHealth);
        }

        [Test]
        public void Heal_IncreasesHealthWithinExpectedRange()
        {
            var p = new Wizard("Healer");
            p.CurrentHealth = 10;
            p.MaxHealth = 100;

            Actions.Heal(p);

            Assert.That(p.CurrentHealth, Is.GreaterThanOrEqualTo(30));
            Assert.That(p.CurrentHealth, Is.LessThanOrEqualTo(60));
        }

        [Test]
        public void Heal_DoesNotExceedMaxHealth()
        {
            var p = new Wizard("Healer");
            p.CurrentHealth = 90;
            p.MaxHealth = 100;

            Actions.Heal(p);

            Assert.AreEqual(100, p.CurrentHealth);
        }
    }
}
