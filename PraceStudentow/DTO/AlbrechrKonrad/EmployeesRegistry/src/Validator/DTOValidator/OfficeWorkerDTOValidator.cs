using WorkersRegistry.DTO;
using WorkersRegistry.Exceptions;
using WorkersRegistry.Interface;
using WorkersRegistry.Repository;

namespace WorkersRegistry.Validator.DTOValidator {

	public class OfficeWorkerDTOValidator : DTOValidatorBase<OfficeWorkerDTO>, IValidatorRecord {
		private readonly EmployeeRepository _employeeRepository = EmployeeRepository.GetInstance();

		public void Validate() {
			if (_employeeRepository.DeskIdExist(ValidatedDTO.DeskId))
			{
				throw new DeskIdExists();
			}
		}
	}
}