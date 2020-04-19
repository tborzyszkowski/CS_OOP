namespace AttributesDemo {
	public class MemoryCalculator {
		public int CurrentValue { get; private set; }

		public void Reset() {
			CurrentValue = 0;
		}
		public void Add(int number) {
			CurrentValue += number;
		}

		public void Subtract(int number) {
			CurrentValue -= number;
		}

		public void Divide(int number) {
			CurrentValue = CurrentValue / number;
		}
	}
}
