using System;

namespace _03Ksiazki {
	class Autor {
		private string _imie;
		private string _nazwisko;

		public Autor(string imie, string nazwisko) {
			if (string.IsNullOrEmpty(imie) || string.IsNullOrEmpty(nazwisko))
				throw new ArgumentException("Imie i nazwisko nie może być puste");
			this._imie = imie;
			this._nazwisko = nazwisko;
		}

		public string Imie { get =>_imie;  }
		public string Nazwisko { get => _nazwisko;  }

		public override bool Equals(object obj)
		{
			return obj is Autor autor &&
				   Imie == autor.Imie &&
				   Nazwisko == autor.Nazwisko;
		}
	}
}
