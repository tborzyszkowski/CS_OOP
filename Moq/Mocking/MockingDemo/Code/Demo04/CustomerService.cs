namespace Demo04.Code {
    public class CustomerService {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMailingAddressFactory _mailingAddressFactory;

        public CustomerService(ICustomerRepository customerRepository,
            IMailingAddressFactory mailingAddressFactory) {
            _customerRepository = customerRepository;
            _mailingAddressFactory = mailingAddressFactory;
        }

        public void Create(CustomerToCreateDto customerToCreate) {
            var customer = new Customer(customerToCreate.Name);

            MailingAddress mailingAddress;
            var mailingAddressSuccessfullyCreated =
                _mailingAddressFactory.TryParse(
                   customerToCreate.Address,
                   out mailingAddress);

            customer.MailingAddress = mailingAddress ?? throw new InvalidMailingAddressException();

            _customerRepository.Save(customer);
        }
    }
}