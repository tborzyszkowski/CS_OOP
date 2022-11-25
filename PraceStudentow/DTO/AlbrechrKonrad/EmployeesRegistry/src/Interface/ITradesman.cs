using WorkersRegistry.Enum;

namespace WorkersRegistry.Interface {

	public interface ITradesman {
		EffectivenessScore Effectiveness { get; set; }

		int Provision { get; set; }
	}
}