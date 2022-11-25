using WorkersRegistry.DTO;
using WorkersRegistry.Model;

namespace WorkersRegistry.Interface {

	public interface IAssembler : IAssemblyInstruction {
		EmployeeDTOBase Assemble();

		EmployeeRecordBase Disassemble();
	}
}