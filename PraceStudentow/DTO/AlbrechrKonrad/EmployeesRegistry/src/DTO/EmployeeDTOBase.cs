using WorkersRegistry.Interface;
using WorkersRegistry.Model;

namespace WorkersRegistry.DTO {

	public abstract class EmployeeDTOBase : Employee, IFacility {
		public string StreetName { get; set; }

		public string BuildingNumber { get; set; }

		public string LocalNumber { get; set; }

		public string CityName { get; set; }

		public int CorporationValue { get; protected set; }

		protected EmployeeDTOBase(
			string name,
			string surname,
			int age,
			int experience,
			string streetName,
			string buildingNumber,
			string localNumber,
			string cityName
		) : base(name, surname, age, experience) {
			Name = name;
			Surname = surname;
			Age = age;
			Experience = experience;
			StreetName = streetName;
			BuildingNumber = buildingNumber;
			LocalNumber = localNumber;
			CityName = cityName;
		}

		public override string ToString() {
			return base.ToString()
				+ " "
				+ Name
				+ " "
				+ Surname
				+ " Age: "
				+ Age
				+ " Exp: "
				+ Experience
				+ " Street: "
				+ StreetName
				+ " "
				+ BuildingNumber
				+ "/"
				+ LocalNumber
				+ " "
				+ CityName
				+ ", CorpValue: "
				+ CorporationValue;
		}
	}
}