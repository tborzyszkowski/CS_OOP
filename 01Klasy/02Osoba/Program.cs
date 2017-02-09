using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Osoba {
    class Program {
        static void Main(string[] args) {
            Osoba m = new Osoba();
            Osoba k = new Osoba();

            m.Nazwisko = "Kowalski";
            m.Imie = "Jan";
            //m.rokUrodzenia = 1990;     //błąd kompilacji
            k.Imie = "Anna";
            k.Nazwisko = "Nowak";

            m.UstawRokUrodzenia(1985);
            k.UstawRokUrodzenia(1989);

            Console.WriteLine("k - {0}", k.PobierzInformacje());
            Console.WriteLine("m - {0}", m.PobierzInformacje());
            //k.CzyKobieta();     //błąd kompilacji

            #region Zadanie 2
            m.Zapisz();
            m.Zapisz();
            m.Zapisz();
            Console.WriteLine("Ilość zapisów do pliku: {0}", m.PobierzLiczbeZapisow());

            #endregion
        }
    }
}
