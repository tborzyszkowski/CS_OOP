using System;
using WorkersRegistry.DTO;
using WorkersRegistry.Model;

namespace WorkersRegistry.Interface {

	public interface IAssemblyInstruction {
		Type TypeOfAssemblyDTO { get; }

		Type TypeOfDisassemblyRecord { get; }

		void SetEmployeeDTO(EmployeeDTOBase employeeDTO);

		void SetEmployeeRecord(EmployeeRecordBase employeeRecord);
	}
}