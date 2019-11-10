using Moq;
using NUnit.Framework;
using Demo12.Code;

namespace Demo12.Tests {
    public class CustomerServiceTests {
        [TestFixture]
        public class When_creating_a_customer {
            [Test]
            public void the_workstation_id_should_be_retrieved() {
                //Arrange
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                var mockApplicationSettings = new Mock<IApplicationSettings>();

                mockApplicationSettings.SetupAllProperties();
                mockApplicationSettings.Object.WorkstationId = 2345;


                var customerService = new CustomerService(
                    mockCustomerRepository.Object,
                    mockApplicationSettings.Object);

                //Act
                customerService.Create(new CustomerToCreateDto());

                //Assert
                mockApplicationSettings.VerifyGet(x => x.WorkstationId);
            }
        }
    }
}