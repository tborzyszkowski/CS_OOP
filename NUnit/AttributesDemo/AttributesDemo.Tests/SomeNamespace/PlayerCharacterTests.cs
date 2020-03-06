using System;
using NUnit.Framework;

namespace AttributesDemo.Tests.SomeNamespace {

    [TestFixture]
    public class PlayerCharacterTests {
        private PlayerCharacter sut;
        int i = 0;

        [SetUp]
        public void BeforeEachTest() {
            i++;
            Console.WriteLine($"Before {TestContext.CurrentContext.Test.Name} i: {i}");

            sut = new PlayerCharacter();
        }

        [TearDown]
        public void AfterEachTest() {
            i++;
            Console.WriteLine($"After {TestContext.CurrentContext.Test.Name} i: {i}");
        }

        //#region Fixture
        [OneTimeSetUp]
        public void BeforeAnyTestStarted() {
            i++;
            Console.WriteLine("*** Before PlayerCharacterTests");
        }

        [OneTimeTearDown]
        public void AfterAllTestsFinished() {
            i++;
            Console.WriteLine("*** After PlayerCharacterTests");
            TestContext.WriteLine("*** After PlayerCharacterTests");
        }

        //#endregion 
        [Test]
        public void ShouldHaveNoEmptyDefaultWeapons() {
            Console.WriteLine($"Test {TestContext.CurrentContext.Test.Name} i: {i}");
            Assert.That(sut.Weapons, Is.All.Not.Empty);
        }


        [Test]
        public void ShouldHaveALongBow() {
            Console.WriteLine($"Test {TestContext.CurrentContext.Test.Name} i: {i}");
            Assert.That(sut.Weapons, Contains.Item("Long Bow"));
        }


        [Test]
        public void ShouldHaveAtLeastOneKindOfSword() {
            Console.WriteLine($"Test {TestContext.CurrentContext.Test.Name} i: {i}");
            Assert.That(sut.Weapons, Has.Some.ContainsSubstring("Sword"));
        }


        [Test]
        public void ShouldHaveTwoBows() {
            Console.WriteLine($"Test {TestContext.CurrentContext.Test.Name} i: {i}");
            Assert.That(sut.Weapons, Has.Exactly(2).EndsWith("Bow"));
        }


        [Test]
        public void ShouldNotHaveMoreThanOneTypeOfAGivenWeapon() {
            Console.WriteLine($"Test {TestContext.CurrentContext.Test.Name} i: {i}");
            Assert.That(sut.Weapons, Is.Unique);
        }


        [Test]
        public void ShouldNotHaveAStaffOfWonder() {
            Console.WriteLine($"Test {TestContext.CurrentContext.Test.Name} i: {i}");
            Assert.That(sut.Weapons, Has.None.EqualTo("Staff Of Wonder"));
        }


        [Test]
        public void ShouldHaveDefaultsWeaponsInAlphabeticalOrder() {
            Console.WriteLine($"Test {TestContext.CurrentContext.Test.Name} i: {i}");
            Assert.That(sut.Weapons, Is.Ordered);
        }
    }
}
