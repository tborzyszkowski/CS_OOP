using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Demo02.Code;

namespace Demo02.Tests {
    public class CustomerServiceTests {
        [TestFixture]
        public class When_creating_multiple_customers {
            //shows how to verify that a method was called an explicit number of times
            [Test]
            public void the_customer_repository_should_be_called_once_per_customer() {
                //Arrange
                var listOfCustomerDtos = new List<CustomerToCreateDto>
                    {
                        new CustomerToCreateDto
                            {
                                FirstName = "Sam", LastName = "Sampson"
                            },
                        new CustomerToCreateDto
                            {
                                FirstName = "Bob", LastName = "Builder"
                            },
                        new CustomerToCreateDto
                            {
                                FirstName = "PJ", LastName = "Stud"
                            },
                        new CustomerToCreateDto
                            {
                                FirstName = "Doug", LastName = "Digger"
                            }
                    };

                var mockCustomerRepository = new Mock<ICustomerRepository>();

                var customerService = new CustomerService(mockCustomerRepository.Object);
                //Act
                customerService.Create(listOfCustomerDtos);

                //Assert
                mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()),
                    Times.Exactly(listOfCustomerDtos.Count));
            }
        }
    }
}