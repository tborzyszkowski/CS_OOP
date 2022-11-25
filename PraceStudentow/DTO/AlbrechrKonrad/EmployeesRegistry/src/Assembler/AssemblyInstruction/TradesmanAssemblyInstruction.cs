using WorkersRegistry.DTO;
using WorkersRegistry.Interface;
using WorkersRegistry.Model;

namespace WorkersRegistry.Assembler.AssemblyInstruction {

	public class TradesmanAssemblyInstruction : AssemblyInstructionBase<TradesmanDTO, Tradesman>, IAssembler {
		public EmployeeDTOBase Assemble() {
			return new TradesmanDTO(
				EmployeeRecord.Name,
				EmployeeRecord.Surname,
				EmployeeRecord.Age,
				EmployeeRecord.Experience,
				EmployeeRecord.Facility.StreetName,
				EmployeeRecord.Facility.BuildingNumber,
				EmployeeRecord.Facility.LocalNumber,
				EmployeeRecord.Facility.CityName,
				EmployeeRecord.Provision,
				EmployeeRecord.Effectiveness
			)
			{
				Id = EmployeeRecord.Id
			};
		}

		public EmployeeRecordBase Disassemble() {
			return new Tradesman(
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
				EmployeeDTO.Effectiveness,
				EmployeeDTO.Provision
			);
		}
	}
}