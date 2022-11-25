using WorkersRegistry.Validator.DTOValidator;

namespace WorkersRegistry.Validator {

	public class DefaultEmployeeDTOValidators : EmployeeDTOValidators {
		public DefaultEmployeeDTOValidators() {
			Add(new OfficeWorkerDTOValidator());
		}
	}
}