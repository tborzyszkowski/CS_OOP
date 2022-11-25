using WorkersRegistry.Interface;

namespace WorkersRegistry.Model {

	public class Employee : IEmployee {
		public int Id { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public int Age { get; set; }

		public int Experience { get; set; }

		public Employee(string name, string surname, int age, int experience) {
			Name = name;
			Surname = surname;
			Age = age;
			Experience = experience;
		}
	}
}