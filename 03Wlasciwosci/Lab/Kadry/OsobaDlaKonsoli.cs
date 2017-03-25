using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadry
{
    class OsobaDlaKonsoli
    {
        private Osoba osoba;
        public Osoba Osoba
        {
            set { osoba = value; }
            get { return osoba; }
        }

        public OsobaDlaKonsoli()
        {
            Console.Write("Podaj imię: ");
            string imie = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            string nazwisko = Console.ReadLine();
            int numerEwidencyjny;
            do
            {
                Console.Write("Podaj numer ewidencyjny: ");
            }
            while (!int.TryParse(Console.ReadLine(), out numerEwidencyjny));
            int rokUrodzenia;
            do
            {
                Console.Write("Podaj rok urodzenia: ");
            }
            while (!int.TryParse(Console.ReadLine(), out rokUrodzenia));
            Console.WriteLine("Podaj adres zamieszkania:");
            AdresDlaKonsoli adr = new AdresDlaKonsoli();
            this.Osoba = new Osoba(numerEwidencyjny, rokUrodzenia, imie, nazwisko, adr.Adres);
        }
        public OsobaDlaKonsoli(Osoba osoba)
        {
            this.Osoba = osoba;
        }

  
        public void ZmienNazwisko()
        {
            Console.Write("Podaj nazwisko: ");
            Osoba.Nazwisko = Console.ReadLine();
        }
        public void ZmienAdres()
        {
            Console.WriteLine("Podaj adres zamieszkania:");
            AdresDlaKonsoli adr = new AdresDlaKonsoli();
            Osoba.AdresZamieszkania = adr.Adres;
        }
        
        public void WypiszOsobe()
        {
            Console.Write("Pan(i) {0} {1} numer ewidencyjny {2} lat {3} ",
                Osoba.Imie, Osoba.Nazwisko, Osoba.NumerEwidencyjny, Osoba.Wiek);
            AdresDlaKonsoli adr = new AdresDlaKonsoli(Osoba.AdresZamieszkania);
            adr.WypiszAdres();
        }
    }
}
