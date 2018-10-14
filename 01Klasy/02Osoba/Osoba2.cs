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
            string nazwa = string.Format($"{Imie}{Nazwisko}{iloscZapisow}.txt");
            try {
                sw = new StreamWriter(nazwa);
                sw.WriteLine($"Numer zapisu: {iloscZapisow}");
                sw.WriteLine($"Imie: {Imie}\nNazwisko: {Nazwisko}");
                sw.WriteLine($"Rok urodzenia: {rokUrodzenia}");
            }
            finally {
                if (sw != null)
                    sw.Close();
            }
        }
    }

}
