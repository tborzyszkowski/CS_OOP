using System;

namespace _01Instrumenty
{
	class Instrument
	{
		protected int waga = 0;

		public void Graj1()
		{
			Console.WriteLine("Instrument.Graj1: Cisza");
		}
		public virtual void Graj2()
		{
			Console.WriteLine("Instrument.Graj2: Cisza 2!!!");
		}
		public override bool Equals(object o) {
			return this.waga == (o as Instrument)?.waga;
		}
	}
}
