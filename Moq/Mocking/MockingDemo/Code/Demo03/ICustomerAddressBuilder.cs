namespace Demo03.Code
{
	public interface ICustomerAddressBuilder
	{
		Address From(CustomerToCreateDto customerToCreate);
	}
}