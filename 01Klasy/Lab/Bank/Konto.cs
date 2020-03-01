using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank {
	class Osoba {
		public string Imie;
		public string Nazwisko;
	}

	class Konto {
		public Osoba Wlasciciel;
		private decimal _saldo = 0;
		private int _pin = 0;

		private bool SprawdzPin(int pin)
		{
			return this._pin == pin;
		}

		public void DokonajWplaty(decimal kwota) {
			if (kwota < 0)
				throw new ArgumentException("Wpłacana kwota nie może być mniejsza od zera");
			_saldo += kwota;
		}

		public string DokonajWyplaty(decimal kwota, int pin) {
			if (SprawdzPin(pin) && _saldo >= kwota)
			{
				_saldo -= kwota;
				return "Operacje zakończono pomyślnie";
			}

			return "Operacja anulowana";
		}

		public bool ZmienPin(int nowy, int stary) {
			if (!SprawdzPin(stary)) return false;
			_pin = nowy;
			return true;
		}


		public string PobierzInformacje(int pin) {
			if (SprawdzPin(pin))
			{
				return $"Pan(i) {Wlasciciel.Imie} {Wlasciciel.Nazwisko} posiada na koncie: {_saldo}";
			}
			return "Brak dostępu";
		}

	}
}
