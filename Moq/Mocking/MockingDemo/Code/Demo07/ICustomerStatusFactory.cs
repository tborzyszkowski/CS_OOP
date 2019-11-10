namespace Demo07.Code {
    public interface ICustomerStatusFactory {
        CustomerStatus CreateFrom(CustomerToCreateDto customerToCreate);
    }
}