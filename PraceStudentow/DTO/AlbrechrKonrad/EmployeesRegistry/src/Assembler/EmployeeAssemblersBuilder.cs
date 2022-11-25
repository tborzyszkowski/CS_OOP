using WorkersRegistry.Interface;

namespace WorkersRegistry.Assembler {

	public class EmployeeAssemblersBuilder {
		public static readonly DefaultEmployeeAssemblers DefaultAssembler = new();

		private readonly EmployeeAssemblers _assembler = new();

		public EmployeeAssemblers Build() => _assembler;

		public void Add(IAssembler assembler) => _assembler.Add(assembler);
	}
}