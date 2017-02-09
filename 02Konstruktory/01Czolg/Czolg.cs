using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Czolg {
    class Czolg {
        private int numerCzolgu;
        private string nazwa;
        private Dzialo dzialo;
        private Punkt pozycja;

        public Czolg(int nrCzolgu, string nazwa, double kaliber, int pozycjaX, int pozycjaY) {
            numerCzolgu = nrCzolgu;
            this.nazwa = nazwa;
            dzialo = new Dzialo(kaliber);
            pozycja = new Punkt(pozycjaX, pozycjaY);
        }

        public Czolg(int nrCzolgu, string nazwa, Dzialo dzialo, Punkt punkt)
            : this(nrCzolgu, nazwa, dzialo.PobierzKaliber(), punkt.PobierzX(), punkt.PobierzY()) {
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

        public string PobierzInformacje() {
            return string.Format("Czołg\n nr:   {0}\n o nazwie: {1}\n kaliber działa: {2}\n znajduje się w punkcie: ({3}; {4})\n",
                numerCzolgu, nazwa, dzialo.PobierzKaliber(), pozycja.PobierzX(), pozycja.PobierzY());
        }

        #region Zadanie 2
        public void ZmienKaliber(double nowyKaliber) {
            dzialo.ZmienKaliber(nowyKaliber);
        }
        public void ZmienPozycje(int x, int y) {
            pozycja.ZmienX(x);
            pozycja.ZmienY(y);
        }
        public void ZmienNazwe(string nowaNazwa) {
            nazwa = nowaNazwa;
        }
        public Czolg Klonuj() {
            return (Czolg)this.MemberwiseClone();
        }
        public Czolg(Czolg prototyp) {
            numerCzolgu = prototyp.numerCzolgu;
            nazwa = prototyp.nazwa;
            dzialo = new Dzialo(prototyp.dzialo);
            pozycja = prototyp.pozycja;
        }
        #endregion

    }
}
