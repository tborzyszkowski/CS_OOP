using Moq;
using NUnit.Framework;
using Demo08.Code;

namespace Demo08.Tests
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer_which_has_an_invalid_address
        {
            [Test]
            public void an_exception_should_be_raised()
            {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockCustomerAddressFactory = new Mock<ICustomerAddressFactory>();

                mockCustomerAddressFactory
                    .Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
                    .Throws<InvalidCustomerAddressException>();

                var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockCustomerAddressFactory.Object);

                //Act & Assert

                Assert.That(
                    () => customerService.Create(new CustomerToCreateDto()),
                    Throws.TypeOf<CustomerCreationException>()
                );
            }
        }
    }
}