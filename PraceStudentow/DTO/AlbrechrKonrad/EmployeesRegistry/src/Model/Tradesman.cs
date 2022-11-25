using WorkersRegistry.Enum;
using WorkersRegistry.Interface;

namespace WorkersRegistry.Model {

	public class Tradesman : EmployeeRecordBase, ITradesman {
		public EffectivenessScore Effectiveness { get; set; }

		public int Provision { get; set; }

		public Tradesman(
			int id,
			string name,
			string surname,
			int age,
			int experience,
			Facility facility,
			EffectivenessScore effectiveness,
			int provision
		) : base(id, name, surname, age, experience, facility) {
			Effectiveness = effectiveness;
			Provision = provision;
		}
	}
}