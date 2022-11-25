using System;
using WorkersRegistry.DTO;

namespace WorkersRegistry.Validator.DTOValidator {

	public abstract class DTOValidatorBase<T> where T : EmployeeDTOBase {
		protected T ValidatedDTO;

		public Type TypeOfClassThisValidatorIsFor => typeof(T);

		public void SetEmployeeDTO(EmployeeDTOBase employeeDTO) {
			ValidatedDTO = employeeDTO as T;
		}
	}
}