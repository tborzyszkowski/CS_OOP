using WorkersRegistry.Exceptions;
using WorkersRegistry.Interface;

namespace WorkersRegistry.DTO {

	public class WorkerDTO : EmployeeDTOBase, IWorker {
		private int _strength;

		public int Strength {
			get => _strength;
			set {
				if (value is < 1 or > 100)
				{
					throw new InvalidPropertyValue();
				}

				_strength = value;
			}
		}

		public WorkerDTO(
			string name,
			string surname,
			int age,
			int experience,
			string streetName,
			string buildingNumber,
			string localNumber,
			string cityName,
			int strength
		) : base(name, surname, age, experience, streetName, buildingNumber, localNumber, cityName) {
			Strength = strength;
			CorporationValue = experience * (strength / age);
		}
	}
}