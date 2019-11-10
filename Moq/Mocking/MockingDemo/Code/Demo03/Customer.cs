namespace Demo03.Code
{
	public class Customer
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public Address MailingAddress { get; set; }

		public Customer(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
	}
}