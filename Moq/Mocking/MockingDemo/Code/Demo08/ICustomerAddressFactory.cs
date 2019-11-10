namespace Demo08.Code {
    public interface ICustomerAddressFactory {
        Address From(CustomerToCreateDto customerToCreate);
    }
}