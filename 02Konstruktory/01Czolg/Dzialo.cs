
namespace _01Czolg
{
	class Dzialo
	{
		private double kaliber;
		public Dzialo(double kaliber)
		{
			this.kaliber = kaliber;
		}

		public double GetKaliber() => kaliber;

		#region Zadanie 2
		public void SetKaliber(double nowyKaliber)
		{
			kaliber = nowyKaliber;
		}

		public Dzialo(Dzialo prototyp)
		{
			this.kaliber = prototyp.kaliber;
		}
		#endregion
	}
}
