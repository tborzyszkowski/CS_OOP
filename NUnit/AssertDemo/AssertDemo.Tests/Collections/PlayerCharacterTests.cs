using NUnit.Framework;

namespace AssertDemo.Tests.Collections {
	[TestFixture]
	public class PlayerCharacterTests {
		[Test]
		public void ShouldHaveNoEmptyDefaultWeapons() {
			var sut = new PlayerCharacter();

			Assert.That(sut.Weapons, Is.All.Not.Empty);
		}

		[Test]
		public void ShouldHaveALongBow() {
			var sut = new PlayerCharacter();

			Assert.That(sut.Weapons, Contains.Item("Long Bow"));
		}

		[Test]
		public void ShouldHaveAtLeastOneKindOfSword() {
			var sut = new PlayerCharacter();

			Assert.That(sut.Weapons, Has.Some.Contains("Sword"));
		}

		[Test]
		public void ShouldHaveTwoBows() {
			var sut = new PlayerCharacter();

			Assert.That(sut.Weapons, Has.Exactly(2).EndsWith("Bow"));
		}

		[Test]
		public void ShouldNotHaveMoreThanOneTypeOfAGivenWeapon() {
			var sut = new PlayerCharacter();

			Assert.That(sut.Weapons, Is.Unique);
		}

		[Test]
		public void ShouldNotHaveAStaffOfWonder() {
			var sut = new PlayerCharacter();

			Assert.That(sut.Weapons, Has.None.EqualTo("Staff Of Wonder"));
		}

		[Test]
		public void ShouldHaveAllExpectedWeapons() {
			var sut = new PlayerCharacter();

			var expectedWeapons = new[]
								  {
									  "Long Bow",
									  "Short Sword",
									  "Short Bow"
								  };

			Assert.That(sut.Weapons, Is.EquivalentTo(expectedWeapons));
		}

		[Test]
		public void ShouldHaveDefaultsWeaponsInAlphabeticalOrder() {
			var sut = new PlayerCharacter();

			Assert.That(sut.Weapons, Is.Ordered);
		}
	}
}
