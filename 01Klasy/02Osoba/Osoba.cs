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
            if (Imie.EndsWith("a")) {
                return true;
            }
            return false;
        }

        public string PobierzInformacje() {
            string tytul = "";
            if (Imie != null) {
                if (CzyKobieta())
                    tytul = "Pani";
                else
                    tytul = "Pan";
            }
            return string.Format("{0} {1} {2} ur. w {3} roku.",
                tytul, Imie, Nazwisko, rokUrodzenia);
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
