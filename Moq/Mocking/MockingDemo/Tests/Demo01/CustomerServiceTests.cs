using Moq;
using NUnit.Framework;
using Demo01.Code;

namespace Demo01.Tests
{
	public class CustomerServiceTests
	{
		[TestFixture]
		public class When_creating_a_customer
		{
			[Test]
			public void the_repository_save_should_be_called()
			{
				//Arrange
				var mockRepository = new Mock<ICustomerRepository>();

				mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));

				var customerService = new CustomerService(mockRepository.Object);

				//Act
				customerService.Create(new CustomerToCreateDto());

				//Assert
				mockRepository.VerifyAll();
			}
		}
	}
}