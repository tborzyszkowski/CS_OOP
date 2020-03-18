using System;

namespace AssertDemo {
	public class SpecialDateStore {
		public DateTime DateOf(SpecialDates specialDate) {
			switch (specialDate)
			{
				case SpecialDates.NewMillennium:
					return new DateTime(2000, 1, 1, 0, 0, 0, 0);
				default:
					throw new ArgumentOutOfRangeException("specialDate");
			}
		}
	}
}