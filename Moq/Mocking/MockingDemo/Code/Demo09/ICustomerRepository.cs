namespace Demo09.Code {
    public interface ICustomerRepository {
        void Save(Customer customer);
        string LocalTimeZone { get; set; }
    }
}