using WorkersRegistry.Interface;

namespace WorkersRegistry.Model {

	public class OfficeWorker : EmployeeRecordBase, IOfficeWorker {
		public int Intellect { get; set; }
		public int DeskId { get; set; }

		public OfficeWorker(
			int id,
			string name,
			string surname,
			int age,
			int experience,
			Facility facility,
			int intellect,
			int deskId
		) : base(id, name, surname, age, experience, facility) {
			Intellect = intellect;
			DeskId = deskId;
		}
	}
}