using System;
using System.Collections.Generic;
using WorkersRegistry.Assembler;
using WorkersRegistry.DTO;
using WorkersRegistry.Service;
using WorkersRegistry.Validator;

namespace WorkersRegistry {

	public class MainEmployeesRegistry {
		private readonly EmployeeService _employeeService;

		public MainEmployeesRegistry() {
			_employeeService = new EmployeeService(
				EmployeeDTOValidatorsBuilder.DefaultValidators,
				EmployeeAssemblersBuilder.DefaultAssembler
			);
		}

		public MainEmployeesRegistry(
			EmployeeDTOValidators employeeDTOValidators,
			EmployeeAssemblers employeeAssemblers
		) {
			_employeeService = new EmployeeService(employeeDTOValidators, employeeAssemblers);
		}

		public void AddEmployee(EmployeeDTOBase employeeDTO) {
			_employeeService.AddEmployee(employeeDTO);
		}

		public void DeleteEmployee(int id) {
			_employeeService.DeleteEmployeeById(id);
		}

		public void AddEmployees(List<EmployeeDTOBase> employeeDTOs) {
			_employeeService.AddEmployees(employeeDTOs);
		}

		public void DisplayEmployeesSortedByExpAgeSurname() {
			foreach (var employeeDTO in _employeeService.GetRecordsSortedByExpAgeSurname())
			{
				Console.WriteLine(employeeDTO);
			}
		}

		public void DisplayEmployeesInCity(string cityName) {
			foreach (var employeeDTO in _employeeService.GetByCityName(cityName))
			{
				Console.WriteLine(employeeDTO);
			}
		}

		public void DisplayAllEmployees() {
			foreach (var employeeDTO in _employeeService.GetAllEmployees())
			{
				Console.WriteLine(employeeDTO);
			}
		}
	}
}