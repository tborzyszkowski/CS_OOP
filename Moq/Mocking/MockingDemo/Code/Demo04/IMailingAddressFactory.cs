namespace Demo04.Code
{
	public interface IMailingAddressFactory
	{
		bool TryParse(string address, out MailingAddress mailingAddress);
	}
}