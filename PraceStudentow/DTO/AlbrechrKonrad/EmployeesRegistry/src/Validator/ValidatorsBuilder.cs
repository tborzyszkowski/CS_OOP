using WorkersRegistry.Interface;

namespace WorkersRegistry.Validator {

	public class EmployeeDTOValidatorsBuilder {
		public static readonly DefaultEmployeeDTOValidators DefaultValidators = new();

		private readonly EmployeeDTOValidators _validators = new();

		public EmployeeDTOValidators Build() => _validators;

		public void Add(IValidatorRecord validator) => _validators.Add(validator);
	}
}