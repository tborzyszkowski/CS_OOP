using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Czolg {
	[Serializable()]
	class Czolg : ICloneable {
		private int numerCzolgu;
		private string nazwa;
		private Dzialo dzialo;
		private Punkt pozycja;

		public Czolg(int nrCzolgu, string nazwa, double kaliber, int pozycjaX, int pozycjaY) {
			SetCzolg(nrCzolgu, nazwa, kaliber, pozycjaX, pozycjaY);
		}

		public Czolg(int nrCzolgu, string nazwa, Dzialo dzialo, Punkt punkt)
			: this(nrCzolgu, nazwa, dzialo.GetKaliber(), punkt.GetX(), punkt.GetY()) {
		}

		public Czolg(int nrCzolgu, string nazwa, double kaliber)
			: this(nrCzolgu, nazwa, kaliber, 0, 0) {
		}

		public Czolg(int nrCzolgu, string nazwa)
			: this(nrCzolgu, nazwa, 76.2) {
		}
		public Czolg(int nrCzolgu)
			: this(nrCzolgu, "Rudy") {
		}
		public Czolg()
			: this(102) {
		}
		private void SetCzolg(int nrCzolgu, string nazwa, double kaliber, int pozycjaX, int pozycjaY) {
			this.numerCzolgu = nrCzolgu;
			this.nazwa = nazwa;
			this.dzialo = new Dzialo(kaliber);
			this.pozycja = new Punkt(pozycjaX, pozycjaY);
		}
		public override string ToString() =>
			$"Czołg\n nr:\t{numerCzolgu}\n o nazwie: {nazwa}\t hash: {this.GetHashCode()}" +
			$"\n kaliber działa: {dzialo.GetKaliber()}\t hash: {this.dzialo.GetHashCode()}" +
			$"\n znajduje się w punkcie: ({pozycja.GetX()}; {pozycja.GetY()})\n";

		#region Zadanie 2
		public void SetKaliber(double nowyKaliber) {
			dzialo.SetKaliber(nowyKaliber);
		}
		public void SetPozycja(int x, int y) {
			pozycja.SetX(x);
			pozycja.SetY(y);
		}
		public void SetNazwa(string nowaNazwa) {
			nazwa = nowaNazwa;
		}

		public Czolg Klonuj() {
			return this.MemberwiseClone() as Czolg;
		}

		public object Clone() {
			//return this.MemberwiseClone();
			return new Czolg(this);
		}

		//public Czolg(Czolg prototyp)
		//{
		//	numerCzolgu = prototyp.numerCzolgu;
		//	nazwa = prototyp.nazwa;
		//	dzialo = new Dzialo(prototyp.dzialo);
		//	pozycja = prototyp.pozycja;
		//}

		public Czolg(Czolg prototyp) :
			this(
				prototyp.numerCzolgu,
				prototyp.nazwa,
				prototyp.dzialo.GetKaliber(),
				prototyp.pozycja.GetX(),
				prototyp.pozycja.GetY()) { }
		#endregion

	}
}
