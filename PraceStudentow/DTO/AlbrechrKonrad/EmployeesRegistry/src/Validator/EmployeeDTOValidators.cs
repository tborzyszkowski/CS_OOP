using System;
using System.Collections.Generic;
using System.Linq;
using WorkersRegistry.DTO;
using WorkersRegistry.Interface;

namespace WorkersRegistry.Validator {

	public class EmployeeDTOValidators {
		public readonly List<IValidatorRecord> Validators = new();

		public void Add(IValidatorRecord validator) {
			Validators.Add(validator);
		}

		public void Validate(EmployeeDTOBase employeeDTO) {
			var validator = Validators.Single(
				validator => validator.TypeOfClassThisValidatorIsFor == employeeDTO.GetType()
			);

			validator.SetEmployeeDTO(employeeDTO);
			validator.Validate();
		}

		public bool HasValidator(EmployeeDTOBase employeeDTO) {
			return Validators.Exists(
				validator => validator.TypeOfClassThisValidatorIsFor == employeeDTO.GetType()
			);
		}
	}
}