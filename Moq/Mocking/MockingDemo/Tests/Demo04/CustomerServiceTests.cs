using Moq;
using NUnit.Framework;
using Demo04.Code;

namespace Demo04.Tests
{
	public class CustomerServiceTests
	{
		[TestFixture]
		public class When_creating_a_customer
		{
			[Test]
			public void the_customer_should_be_persisted()
			{
				//Arrange
				var mockCustomerRepository = new Mock<ICustomerRepository>();
				var mockMailingAddressFactory = new Mock<IMailingAddressFactory>();

				var mailingAddress = new MailingAddress { Country = "Canada" };
				mockMailingAddressFactory
					.Setup(x => x.TryParse(It.IsAny<string>(), out mailingAddress))
					.Returns(true);

				var customerService = new CustomerService(
						mockCustomerRepository.Object,
						mockMailingAddressFactory.Object
					);

				//Act
				customerService.Create(new CustomerToCreateDto());

				//Assert
				mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));
			}
		}
	}
}