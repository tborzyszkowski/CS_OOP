using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Osoba {
    partial class Osoba {
        partial void zapisz(int licznik) {
            StreamWriter sw = null;
            string nazwa = string.Format("{0}{1}{2}.txt", Imie, Nazwisko, iloscZapisow);
            try {
                sw = new StreamWriter(nazwa);
                sw.WriteLine("Numer zapisu: {0}", iloscZapisow);
                sw.WriteLine("Imie: {0}\nNazwisko: {1}", Imie, Nazwisko);
                sw.WriteLine("Rok urodzenia: {0}", rokUrodzenia);
            }
            finally {
                if (sw != null)
                    sw.Close();
            }
        }
    }

}
