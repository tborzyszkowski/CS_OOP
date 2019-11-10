using System.Collections.Generic;

namespace Demo05.Code
{
	public class CustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IIdFactory _idFactory;

		public CustomerService(
			ICustomerRepository customerRepository,
			IIdFactory idFactory)
		{
			_customerRepository = customerRepository;
			_idFactory = idFactory;
		}

		public void Create(IEnumerable<CustomerToCreateDto> customersToCreate)
		{
			foreach (var customerToCreateDto in customersToCreate)
			{
				var customer = new Customer(
					customerToCreateDto.FirstName,
					customerToCreateDto.LastName);

				customer.Id = _idFactory.Create();

				_customerRepository.Save(customer);
			}
		}
	}
}