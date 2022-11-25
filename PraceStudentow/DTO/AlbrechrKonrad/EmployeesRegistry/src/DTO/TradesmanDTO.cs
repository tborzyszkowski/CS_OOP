using WorkersRegistry.Enum;
using WorkersRegistry.Exceptions;
using WorkersRegistry.Interface;

namespace WorkersRegistry.DTO {

	public class TradesmanDTO : EmployeeDTOBase, ITradesman {
		private int _provision;

		public int Provision {
			get => _provision;
			set {
				if (value is < 1 or > 100)
				{
					throw new InvalidPropertyValue();
				}

				_provision = value;
			}
		}

		public EffectivenessScore Effectiveness { get; set; }

		public TradesmanDTO(
			string name,
			string surname,
			int age,
			int experience,
			string streetName,
			string buildingNumber,
			string localNumber,
			string cityName,
			int provision,
			EffectivenessScore effectiveness
		) : base(name, surname, age, experience, streetName, buildingNumber, localNumber, cityName) {
			Effectiveness = effectiveness;
			Provision = provision;
			CorporationValue = experience * (int)Effectiveness;
		}
	}
}