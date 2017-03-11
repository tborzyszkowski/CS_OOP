using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadry
{
    class Adres
    {
        private string miejscowosc;
        private string kod;
        private string nazwaUlicy;
        private int numerDomu;
        private int? numerMieszkania;

        public Adres(int numerDomu, int? numerMieszkania, string nazwaUlicy, string kod, string miejscowosc)
        {
            this.numerDomu = numerDomu;
            this.numerMieszkania = numerMieszkania;
            this.nazwaUlicy = nazwaUlicy;
            this.kod = kod;
            this.miejscowosc = miejscowosc;
        }
        public Adres(int numerDomu, int? numerMieszkania, string nazwaUlicy)
            :this(numerDomu,numerMieszkania,nazwaUlicy,"02-222", "Warszawa")
        {            
        }
        public Adres(int numerDomu, int? numerMieszkania)
            : this(numerDomu, numerMieszkania, "Aleje Jerozolimskie")
        {
        }
        public Adres(int numerDomu)
            :this(numerDomu, null)
        {            
        }

        public Adres(Adres adres)
            : this(adres.numerDomu, adres.numerMieszkania, adres.nazwaUlicy, adres.kod,adres.miejscowosc)
        {
        }

        public string ZwrocInformacjeAdresowe()
        {
            return numerMieszkania != null ?
                string.Format("{0} {1} ul. {2} {3} m. {4}", kod, miejscowosc, nazwaUlicy, numerDomu, numerMieszkania) :
                string.Format("{0} {1} ul. {2} {3}", kod, miejscowosc, nazwaUlicy, numerDomu);
        }
        public string ZwrocMiejscowosc()
        {
            return miejscowosc;
        }
        public string ZwrocNazweUlicy()
        {
            return nazwaUlicy;
        }
        public string ZwrocKod()
        {
            return kod;
        }
        public int ZwrocNumerDomu()
        {
            return numerDomu;
        }
        public int? ZwrocNumerMieszkania()
        {
            return numerMieszkania;
        }
        public void ZmienAderes()
        {
            Console.Write("Podaj nazwę miejscowści: ");
            miejscowosc = Console.ReadLine();
            Console.Write("Podaj kod: ");
            kod = Console.ReadLine();
            Console.Write("Podaj nazwę ulicy: ");
            nazwaUlicy = Console.ReadLine();
            do
            {
                Console.Write("Podaj numer domu: ");                
            }
            while (!int.TryParse(Console.ReadLine(), out numerDomu));
            Console.Write("Czy jest numer mieszkania <t/n>: ");
            char c = Console.ReadKey().KeyChar;
            if (c == 't')
            {
                int i;
                Console.WriteLine();
                do
                {
                    Console.Write("Podaj numer meszkania: ");
                }
                while (!int.TryParse(Console.ReadLine(), out i));
                numerMieszkania = i;
            }
            else
            {
                numerMieszkania = null;
            }
        }
    }
    class Osoba
    {
        private string nazwisko;
        private string imie;
        private int numerEwidencyjny;
        private Adres adresZamieszkania;

        public Osoba(int numerEwidencyjny, string imie, string nazwisko, int numerDomu, int? numerMieszkania, string nazwaUlicy, string kod, string miejscowosc)
        {
            this.numerEwidencyjny = numerEwidencyjny;
            this.imie = imie;
            this.nazwisko = nazwisko;
            adresZamieszkania = new Adres(numerDomu, numerMieszkania, nazwaUlicy, kod, miejscowosc);
        }

        public Osoba(int numerEwidencyjny, string imie, string nazwisko, Adres adres)
            : this(numerEwidencyjny, imie, nazwisko, adres.ZwrocNumerDomu(), adres.ZwrocNumerMieszkania(), adres.ZwrocNazweUlicy(),
            adres.ZwrocKod(), adres.ZwrocMiejscowosc())
        {
        }

        public Osoba(int numerEwidencyjny, string imie, int numerDomu)
            : this(numerEwidencyjny, imie, "Kowalski", numerDomu, null, "Aleje Jerrozolimskie", "02-222", "Warszawa")
        {
        }
        public Osoba(Osoba osoba)
        {
            numerEwidencyjny = osoba.numerEwidencyjny;
            imie = osoba.imie;
            nazwisko = osoba.nazwisko;
            adresZamieszkania = new Adres(osoba.adresZamieszkania);            
        }

        public string ZwrocInnformacjeOsobowe()
        {
            return string.Format("Pan(i) {0} {1} o numerze ewidencyjnym {2} zamieszkały(a): {3}",
                imie, nazwisko, numerEwidencyjny, adresZamieszkania.ZwrocInformacjeAdresowe());
        }

        public Osoba Klonuj()
        {
            return (Osoba)this.MemberwiseClone();
        }
        public void ZmienDaneOsobowe()
        {
            Console.Write("Podaj imię: ");
            imie = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            nazwisko = Console.ReadLine();
            do
            {
                Console.Write("Podaj numer ewidencyjny: ");
            }
            while(!int.TryParse(Console.ReadLine(), out numerEwidencyjny));
            adresZamieszkania.ZmienAderes();
        }
    }
}
