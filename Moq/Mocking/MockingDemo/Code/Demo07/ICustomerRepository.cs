namespace Demo07.Code {
    public interface ICustomerRepository {
        void SaveSpecial(Customer customer);
        void Save(Customer customer);
    }
}