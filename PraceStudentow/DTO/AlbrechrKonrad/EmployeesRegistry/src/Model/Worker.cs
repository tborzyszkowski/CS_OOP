using WorkersRegistry.Interface;

namespace WorkersRegistry.Model {

	public class Worker : EmployeeRecordBase, IWorker {
		public int Strength { get; set; }

		public Worker(
			int id,
			string name,
			string surname,
			int age,
			int experience,
			Facility facility,
			int strength
		) : base(id, name, surname, age, experience, facility) {
			Strength = strength;
		}
	}
}