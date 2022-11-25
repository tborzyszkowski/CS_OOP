using WorkersRegistry.Assembler.AssemblyInstruction;

namespace WorkersRegistry.Assembler {

	public class DefaultEmployeeAssemblers : EmployeeAssemblers {
		public DefaultEmployeeAssemblers() {
			Add(new OfficeWorkerAssemblyInstruction());
			Add(new TradesmanAssemblyInstruction());
			Add(new WorkerAssemblyInstruction());
		}
	}
}