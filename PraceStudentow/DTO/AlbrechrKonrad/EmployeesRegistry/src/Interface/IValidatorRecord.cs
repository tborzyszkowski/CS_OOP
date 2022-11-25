using System;
using WorkersRegistry.DTO;

namespace WorkersRegistry.Interface {

	public interface IValidatorRecord : IValidator {
		Type TypeOfClassThisValidatorIsFor { get; }

		void SetEmployeeDTO(EmployeeDTOBase employeeDTO);
	}
}