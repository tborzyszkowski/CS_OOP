using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Ksiazki {
    class Autor {
        private string imie;
        private string nazwisko;

        public Autor(string imie, string nazwisko) {
            if (string.IsNullOrEmpty(imie) || string.IsNullOrEmpty(nazwisko))
                throw new ArgumentException("Imie i nazwisko nie może być puste");
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public string Imie { get { return imie; } }
        public string Nazwisko { get { return nazwisko; } }
    }
}
