using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Czolg {
    class Program {
        static void Main(string[] args) {
            Punkt p1 = new Punkt(); //wszystko OK - struktura
            //Dzialo dz = new Dzialo(); //Blad - dla klas nie jest definiowany konstruktor domyslny gdy istnieje inny konstruktor
            Dzialo dz1 = new Dzialo(78);

            Czolg czolg1 = new Czolg(100, "Czolg 1", dz1, p1);
            Czolg czolg2 = new Czolg(102);
            Czolg czolg3 = new Czolg(103, "Czolg 3", 83.5, 10, 34);
            Console.WriteLine(czolg1.PobierzInformacje());
            Console.WriteLine(czolg2.PobierzInformacje());
            Console.WriteLine(czolg3.PobierzInformacje());

            #region Zadanie 2
            Console.WriteLine("\nKopiowanie płytkie.");
            Czolg oryginal1 = new Czolg(200, "Oryginal 1", 100, 10, 10);
            Czolg klon1 = oryginal1.Klonuj();
            Console.WriteLine("Oryginał: {0}", oryginal1.PobierzInformacje());
            Console.WriteLine("Klon:     {0}", klon1.PobierzInformacje());
            Console.WriteLine("Zmieniamy klona: ");
            klon1.ZmienKaliber(300);
            klon1.ZmienNazwe("Klon 1: ");
            klon1.ZmienPozycje(55, 55);
            Console.WriteLine("Oryginał: {0}", oryginal1.PobierzInformacje());
            Console.WriteLine("Klon:     {0}", klon1.PobierzInformacje());

            Console.WriteLine("\nKopiowanie głębokie.");
            Czolg oryginal2 = new Czolg(200, "Oryginal 2", 100, 10, 10);
            Czolg klon2 = new Czolg(oryginal2);
            Console.WriteLine("Oryginał: {0}", oryginal2.PobierzInformacje());
            Console.WriteLine("Klon:     {0}", klon2.PobierzInformacje());
            Console.WriteLine("Zmieniamy klona: ");
            klon2.ZmienKaliber(300);
            klon2.ZmienNazwe("Klon 2");
            klon2.ZmienPozycje(55, 55);
            Console.WriteLine("Oryginał: {0}", oryginal2.PobierzInformacje());
            Console.WriteLine("Klon:     {0}", klon2.PobierzInformacje());

            #endregion

        }
    }
}
