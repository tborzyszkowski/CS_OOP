namespace Demo12.Code {
    public class CustomerService {
        private readonly ICustomerRepository _customerRepository;
        private readonly IApplicationSettings _applicationSettings;

        public CustomerService(ICustomerRepository customerRepository, IApplicationSettings applicationSettings) {
            _customerRepository = customerRepository;
            _applicationSettings = applicationSettings;
        }

        public void Create(CustomerToCreateDto customerToCreate) {
            var customer = new Customer(customerToCreate.Name);

            var workstationId = _applicationSettings.WorkstationId;

            if (!workstationId.HasValue)
            {
                throw new InvalidWorkstationIdException();
            }

            customer.WorkstationCreatedOn = workstationId.Value;

            _customerRepository.Save(customer);
        }
    }
}