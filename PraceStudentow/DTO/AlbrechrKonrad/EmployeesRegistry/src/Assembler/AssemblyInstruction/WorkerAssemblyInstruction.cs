using WorkersRegistry.DTO;
using WorkersRegistry.Interface;
using WorkersRegistry.Model;

namespace WorkersRegistry.Assembler.AssemblyInstruction {

	public class WorkerAssemblyInstruction : AssemblyInstructionBase<WorkerDTO, Worker>, IAssembler {
		public EmployeeDTOBase Assemble() {
			return new WorkerDTO(
				EmployeeRecord.Name,
				EmployeeRecord.Surname,
				EmployeeRecord.Age,
				EmployeeRecord.Experience,
				EmployeeRecord.Facility.StreetName,
				EmployeeRecord.Facility.BuildingNumber,
				EmployeeRecord.Facility.LocalNumber,
				EmployeeRecord.Facility.CityName,
				EmployeeRecord.Strength
			)
			{
				Id = EmployeeRecord.Id
			};
		}

		public EmployeeRecordBase Disassemble() {
			return new Worker(
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
				EmployeeDTO.Strength
			);
		}
	}
}