namespace Demo05.Code
{
	public class Customer
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Id { get; set; }

		public Customer(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
	}
}