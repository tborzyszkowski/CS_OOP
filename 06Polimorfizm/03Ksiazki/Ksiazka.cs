using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Ksiazki {
    class Ksiazka {
        public Autor Autor { set; get; }
        public string Tytul { set; get; }
        public int RokWydania { set; get; }
        public string Wydawnictwo { set; get; }
        public string Isbn { set; get; }

        public Ksiazka(string imie, string nazwisko, string tytul, int rok, string wyd, string isbn) {
            Autor = new Autor(imie, nazwisko);
            Tytul = tytul;
            RokWydania = rok;
            Wydawnictwo = wyd;
            Isbn = isbn;
        }

        public Ksiazka(string imie, string nazwisko, string tytul) :
            this(imie, nazwisko, tytul, 2000, "ABC", null) { }

        public override string ToString() {
            return string.Format("{0} {1}., \"{2}\", {3}, {4}, {5}",
                Autor.Nazwisko, Autor.Imie[0], Tytul, Wydawnictwo,
                RokWydania, Isbn);
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            Ksiazka k = (Ksiazka)obj;
            if (
                    (Isbn != null || k.Isbn != null) && //jeżeli któryś Isbn nie jest nullem
                    (Isbn == null || k.Isbn == null ||  //to sprawdzamy czy jeden z nich jest nullem
                    ! Isbn.Equals(k.Isbn))              //lub nie są równe
                )
                return false;
            if (!string.Equals(Tytul, k.Tytul)) return false;
            if (!Autor.Equals(Autor, k.Autor)) return false;
            if (RokWydania != k.RokWydania) return false;
            if (Wydawnictwo != k.Wydawnictwo) return false;
            return true;
        }

        public override int GetHashCode() {
            if (Isbn != null)
                return Isbn.GetHashCode();
            return ToString().GetHashCode();
        }
    }
}
