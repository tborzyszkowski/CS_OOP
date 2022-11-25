using System;

namespace _03Ksiazki {
	class Autor {
		public Autor(string imie, string nazwisko) {
			if (string.IsNullOrEmpty(imie) || string.IsNullOrEmpty(nazwisko))
				throw new ArgumentException("Imie i nazwisko nie może być puste");
			this.Imie = imie;
			this.Nazwisko = nazwisko;
		}

		public string Imie { get; }
		public string Nazwisko { get; }

		public override bool Equals(object obj) =>
			obj is Autor autor &&
			this.Imie == autor.Imie &&
			this.Nazwisko == autor.Nazwisko;
	}
}
