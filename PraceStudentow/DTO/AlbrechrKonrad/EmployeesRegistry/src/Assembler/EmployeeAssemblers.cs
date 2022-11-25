using System.Collections.Generic;
using System.Linq;
using WorkersRegistry.DTO;
using WorkersRegistry.Interface;
using WorkersRegistry.Model;

namespace WorkersRegistry.Assembler {

	public class EmployeeAssemblers {
		private readonly List<IAssembler> _assemblers = new();

		public void Add(IAssembler assembler) {
			_assemblers.Add(assembler);
		}

		public EmployeeDTOBase Assemble(EmployeeRecordBase employeeRecord) {
			var assembler = _assemblers.Single(
				assembler => assembler.TypeOfDisassemblyRecord == employeeRecord.GetType()
			);

			assembler.SetEmployeeRecord(employeeRecord);

			return assembler.Assemble();
		}

		public EmployeeRecordBase Disassemble(EmployeeDTOBase employeeDTO) {
			var assembler = _assemblers.Single(
				assembler => assembler.TypeOfAssemblyDTO == employeeDTO.GetType()
			);

			assembler.SetEmployeeDTO(employeeDTO);

			return assembler.Disassemble();
		}
	}
}