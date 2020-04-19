using NUnit.Framework;

namespace AssertDemo.Tests.ReferenceEquality {
	[TestFixture]
	public class PlayerCharacterTests {
		[Test]
		public void ReferenceEqualityDemo() {
			var player1 = new PlayerCharacter();
			var player2 = new PlayerCharacter();

			//Assert.That(player1, Is.SameAs(player2));

			var somePlayer = player1;
			Assert.That(somePlayer, Is.SameAs(player1));

			//Assert.That(player1, Is.Not.SameAs(player2));
		}
	}
}
