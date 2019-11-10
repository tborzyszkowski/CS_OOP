namespace Demo08.Code {
    public class CustomerService {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressFactory _customerAddressFactory;

        public CustomerService(ICustomerRepository customerRepository, ICustomerAddressFactory customerAddressFactory) {
            _customerRepository = customerRepository;
            _customerAddressFactory = customerAddressFactory;
        }

        public void Create(CustomerToCreateDto customerToCreate) {
            try
            {
                var customer = new Customer(customerToCreate.Name);
                customer.Address = _customerAddressFactory.From(customerToCreate);
                _customerRepository.Save(customer);
            }
            catch (InvalidCustomerAddressException e)
            {
                throw new CustomerCreationException(e);
            }
        }
    }
}