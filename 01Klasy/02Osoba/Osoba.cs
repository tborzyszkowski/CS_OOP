using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Osoba {
	partial class Osoba {
		public string Imie;
		public string Nazwisko;
		private int rokUrodzenia;

		private bool CzyKobieta() {
			if (!Imie.EndsWith("a")) return false;
			return true;
		}

		public string PobierzInformacje() {
			string tytul = "";
			if (Imie != null)
			{
				if (CzyKobieta())
					tytul = "Pani";
				else
					tytul = "Pan";
			}
			return $"{tytul} {Imie} {Nazwisko} ur. w {rokUrodzenia} roku.";
		}

		public void UstawRokUrodzenia(int rokUrodzenia) {
			if (DateTime.Now.Year - rokUrodzenia < 18)
				throw new ArgumentException("Osoba musi być pełnoletnia");
			this.rokUrodzenia = rokUrodzenia;
		}

		#region Zadanie 2
		private int iloscZapisow = 0;
		public int PobierzLiczbeZapisow() {
			return iloscZapisow;
		}

		partial void zapisz(int licznik);

		public void Zapisz() {
			zapisz(++iloscZapisow);
		}
		#endregion
	}
}
