using System;

namespace AssertDemo {
	public class Calculator {
		public int AddInts(int a, int b) {
			return a + b;
		}
		public double AddDoubles(double a, double b) {
			return a + b;
		}
		public int Divide(int value, int by) {
			if (value > 100)
			{
				throw new ArgumentOutOfRangeException("value"); // bug for demo purposes
			}

			return value / by;
		}
	}
}