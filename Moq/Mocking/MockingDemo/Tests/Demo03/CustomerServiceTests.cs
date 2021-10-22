using Moq;
using NUnit.Framework;
using Demo03.Code;

namespace Demo03.Tests
{
	public class CustomerServiceTests
	{
		[TestFixture]
		public class When_creating_a_new_customer
		{
			//this shows how setting the return value will change the execution flow
			[Test]
			public void an_exception_should_be_thrown_if_the_address_is_not_created()
			{
				//Arrange
				var customerToCreateDto = new CustomerToCreateDto
					{ FirstName = "Bob", LastName = "Builder" };
				var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
				var mockCustomerRepository = new Mock<ICustomerRepository>();

				mockAddressBuilder
					.Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
					.Returns(() => null);

				var customerService = new CustomerService(
					mockAddressBuilder.Object,
					mockCustomerRepository.Object);

				//Act & Assert
				Assert.That(
					() => customerService.Create(customerToCreateDto),
					Throws.TypeOf<InvalidCustomerMailingAddressException>()
				);
			}

			[Test]
			public void the_customer_should_be_saved_if_the_address_was_created()
			{
				//Arrange
				var customerToCreateDto = new CustomerToCreateDto 
					{ FirstName = "Bob", LastName = "Builder" };
				var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
				var mockCustomerRepository = new Mock<ICustomerRepository>();

				mockAddressBuilder
					.Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
					.Returns(() => new Address());

				var customerService = new CustomerService(
						mockAddressBuilder.Object,
						mockCustomerRepository.Object
					);

				//Act
				customerService.Create(customerToCreateDto);

				//Assert
				mockCustomerRepository.Verify(y => y.Save(It.IsAny<Customer>()));
			}
		}
	}
}