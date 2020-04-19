using System;

namespace AttributesDemo {
	public class ClassWithIntermittentBug {
		public void DoWork() {
			// simulated intermittent bug
			if (DateTime.Now.Ticks % 2 == 0)
			{
				//throw new ApplicationException("Simulated bug");
			}
		}
	}
}
