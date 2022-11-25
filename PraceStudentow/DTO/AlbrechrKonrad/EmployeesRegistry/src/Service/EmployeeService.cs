using System;
using System.Collections.Generic;
using System.Linq;
using WorkersRegistry.Assembler;
using WorkersRegistry.DTO;
using WorkersRegistry.Repository;
using WorkersRegistry.Validator;

namespace WorkersRegistry.Service {

	public class EmployeeService {
		private readonly EmployeeDTOValidators _validators;
		private readonly EmployeeAssemblers _assemblers;
		private readonly EmployeeRepository _employeeRepository = EmployeeRepository.GetInstance();

		public EmployeeService(EmployeeDTOValidators validators, EmployeeAssemblers assemblers) {
			_validators = validators;
			_assemblers = assemblers;
		}

		public void AddEmployee(EmployeeDTOBase employeeDTO) {
			if (_validators.HasValidator(employeeDTO))
			{
				try
				{
					_validators.Validate(employeeDTO);
				}
				catch (Exception e)
				{
					Console.WriteLine("Validation error!");
					throw e;
				}
			}

			_employeeRepository.Add(_assemblers.Disassemble(employeeDTO));
		}

		public void DeleteEmployeeById(int id) {
			_employeeRepository.DeleteById(id);
		}

		public void AddEmployees(List<EmployeeDTOBase> employeeDTOs) {
			foreach (var employeeDTO in employeeDTOs)
			{
				AddEmployee(employeeDTO);
			}
		}

		public IEnumerable<EmployeeDTOBase> GetRecordsSortedByExpAgeSurname() {
			var employees = _employeeRepository
				.GetAllEmployees()
				.Select(record => _assemblers.Assemble(record));

			return employees
				.OrderByDescending(dto => dto.Experience)
				.ThenBy(dto => dto.Age)
				.ThenByDescending(dto => dto.Surname);
		}

		public IEnumerable<EmployeeDTOBase> GetByCityName(string cityName) {
			return _employeeRepository
				.GetByCityName(cityName)
				.Select(record => _assemblers.Assemble(record));
		}

		public IEnumerable<EmployeeDTOBase> GetAllEmployees() {
			return _employeeRepository.GetAllEmployees().Select(record => _assemblers.Assemble(record));
		}
	}
}