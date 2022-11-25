using System;
using WorkersRegistry.DTO;
using WorkersRegistry.Interface;
using WorkersRegistry.Model;

namespace WorkersRegistry.Assembler.AssemblyInstruction {

	public abstract class AssemblyInstructionBase<TDto, TRecord> : IAssemblyInstruction
		where TDto : EmployeeDTOBase
		where TRecord : EmployeeRecordBase {
		protected TDto EmployeeDTO;

		protected TRecord EmployeeRecord;

		public Type TypeOfAssemblyDTO => typeof(TDto);

		public Type TypeOfDisassemblyRecord => typeof(TRecord);

		public void SetEmployeeDTO(EmployeeDTOBase employeeDTO) {
			EmployeeDTO = employeeDTO as TDto;
		}

		public void SetEmployeeRecord(EmployeeRecordBase employeeRecord) {
			EmployeeRecord = employeeRecord as TRecord;
		}
	}
}