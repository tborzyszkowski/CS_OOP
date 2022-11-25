namespace WorkersRegistry.Interface {

	public interface IEmployee {
		int Id { get; set; }

		string Name { get; set; }

		string Surname { get; set; }

		int Age { get; set; }

		int Experience { get; set; }
	}
}