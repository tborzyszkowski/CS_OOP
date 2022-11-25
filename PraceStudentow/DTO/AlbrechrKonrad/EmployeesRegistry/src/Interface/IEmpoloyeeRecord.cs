using WorkersRegistry.Model;

namespace WorkersRegistry.Interface {

	interface IEmployeeRecord : IEmployee {
		Facility Facility { get; set; }
	}
}