using System;
using System.Linq;
using System.Reflection;

using FluentAssertions;
using NUnit.Framework;

namespace TestingPrivate {
	[TestFixture]
	class PersonTest {
		[Test]
		public void PrivatePersonTestShouldBeWellFormated() {
			// Arrange
			var firstName = "Jan";
			var lastName = "Kowalski";

			Type type = typeof(Person);
			var person = Activator.CreateInstance(type, firstName, lastName);
			MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
				.Where(x => x.Name == "PersonText" && x.IsPrivate)
				.First();

			//Act
			var personText = (string)method.Invoke(person, new object[] { firstName, lastName });

			//Assert
			personText.Should()
				.StartWith("Person")
				.And
				.EndWith("!")
				.And
				.Contain(firstName)
				.And
				.Contain(lastName);
		}
	}
}
