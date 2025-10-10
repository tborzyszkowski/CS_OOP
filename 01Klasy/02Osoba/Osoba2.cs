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
            using (sw = new StreamWriter(nazwa))
            {
                try
                {

                    sw.WriteLine($"Numer zapisu: {iloscZapisow}");
                    sw.WriteLine($"Imie: {Imie}\nNazwisko: {Nazwisko}");
                    sw.WriteLine($"Rok urodzenia: {rokUrodzenia}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //         finally
			//{
			//	if (sw != null)
			//		sw.Close();
			//}
		}
	}

}
