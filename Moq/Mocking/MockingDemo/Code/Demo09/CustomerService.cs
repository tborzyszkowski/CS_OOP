using System;

namespace Demo09.Code {
    public class CustomerService {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) {
            _customerRepository = customerRepository;
        }

        public void Create(CustomerToCreateDto customerToCreate) {
            var customer = new Customer(
                customerToCreate.FirstName,
                customerToCreate.LastName);

            _customerRepository.LocalTimeZone =
                TimeZone.CurrentTimeZone.StandardName;

            _customerRepository.Save(customer);
        }
    }
}