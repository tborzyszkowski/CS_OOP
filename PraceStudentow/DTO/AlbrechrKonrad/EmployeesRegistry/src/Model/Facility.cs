using WorkersRegistry.Interface;

namespace WorkersRegistry.Model {

	public class Facility : IFacility {
		public string StreetName { get; set; }

		public string BuildingNumber { get; set; }

		public string LocalNumber { get; set; }

		public string CityName { get; set; }

		public Facility(string streetName, string buildingNumber, string localNumber, string cityName) {
			StreetName = streetName;
			BuildingNumber = buildingNumber;
			LocalNumber = localNumber;
			CityName = cityName;
		}
	}
}