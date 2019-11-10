using System;
using Moq;
using NUnit.Framework;
using Demo06.Code;

namespace Demo06.Tests
{
	public class CustomerServiceTests
	{
		[TestFixture]
		public class When_creating_a_customer
		{
			//verify that specific parameter values are passed to the mock object
			[Test]
			public void a_full_name_should_be_created_from_first_and_last_name()
			{
				//Arrange
				var customerToCreateDto = new CustomerToCreateDto
				{
					FirstName = "Bob",
					LastName = "Builder"
				};

				var mockCustomerRepository = new Mock<ICustomerRepository>();
				var mockFullNameBuilder = new Mock<ICustomerFullNameBuilder>();

				mockFullNameBuilder.Setup(
					x => x.From(It.IsAny<string>(), It.IsAny<string>()));

				var customerService = new CustomerService(
					mockCustomerRepository.Object, mockFullNameBuilder.Object);

				//Act
				customerService.Create(customerToCreateDto);

				//Assert
				mockFullNameBuilder.Verify(x => x.From(
					It.Is<string>(
						fn => fn.Equals(customerToCreateDto.FirstName,
							StringComparison.InvariantCultureIgnoreCase)),
					It.Is<string>(
						ln => ln.Equals(customerToCreateDto.LastName,
							StringComparison.InvariantCultureIgnoreCase))));
			}
		}
	}
}