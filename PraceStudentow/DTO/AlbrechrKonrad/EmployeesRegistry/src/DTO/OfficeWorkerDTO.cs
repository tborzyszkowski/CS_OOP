using WorkersRegistry.Exceptions;
using WorkersRegistry.Interface;

namespace WorkersRegistry.DTO {

	public class OfficeWorkerDTO : EmployeeDTOBase, IOfficeWorker {
		private int _intellect;

		public int Intellect {
			get => _intellect;
			set {
				if (value is < 70 or > 150)
				{
					throw new InvalidPropertyValue();
				}

				_intellect = value;
			}
		}

		public int DeskId { get; set; }

		public OfficeWorkerDTO(
			string name,
			string surname,
			int age,
			int experience,
			string streetName,
			string buildingNumber,
			string localNumber,
			string cityName,
			int intellect,
			int deskId
		) : base(name, surname, age, experience, streetName, buildingNumber, localNumber, cityName) {
			Intellect = intellect;
			DeskId = deskId;
			CorporationValue = experience * intellect;
		}
	}
}