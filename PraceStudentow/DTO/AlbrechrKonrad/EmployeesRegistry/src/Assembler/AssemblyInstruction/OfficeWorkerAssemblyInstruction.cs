using WorkersRegistry.DTO;
using WorkersRegistry.Interface;
using WorkersRegistry.Model;

namespace WorkersRegistry.Assembler.AssemblyInstruction {

	public class OfficeWorkerAssemblyInstruction
		: AssemblyInstructionBase<OfficeWorkerDTO, OfficeWorker>,
			IAssembler {
		public EmployeeDTOBase Assemble() {
			return new OfficeWorkerDTO(
				EmployeeRecord.Name,
				EmployeeRecord.Surname,
				EmployeeRecord.Age,
				EmployeeRecord.Experience,
				EmployeeRecord.Facility.StreetName,
				EmployeeRecord.Facility.BuildingNumber,
				EmployeeRecord.Facility.LocalNumber,
				EmployeeRecord.Facility.CityName,
				EmployeeRecord.Intellect,
				EmployeeRecord.DeskId
			)
			{
				Id = EmployeeRecord.Id
			};
		}

		public EmployeeRecordBase Disassemble() {
			return new OfficeWorker(
				EmployeeDTO.Id,
				EmployeeDTO.Name,
				EmployeeDTO.Surname,
				EmployeeDTO.Age,
				EmployeeDTO.Experience,
				new Facility(
					EmployeeDTO.StreetName,
					EmployeeDTO.BuildingNumber,
					EmployeeDTO.LocalNumber,
					EmployeeDTO.CityName
				),
				EmployeeDTO.Intellect,
				EmployeeDTO.DeskId
			);
		}
	}
}