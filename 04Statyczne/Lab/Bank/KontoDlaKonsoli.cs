using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    static class KontoDlaKonsoli
    {
        private static int pobierzLiczbeInt(string s)
        {
            int pin;
            do
            {
                Console.Write(s);
            }
            while (!int.TryParse(Console.ReadLine(), out pin));
            return pin;
        }
        private static decimal pobierzLiczbeDecimal(string s)
        {
            decimal kwota;
            do
            {
                Console.Write(s);
            }
            while (!decimal.TryParse(Console.ReadLine(), out kwota));
            return kwota;
        }

        public static Konto UtworzKonto()
        {
            Console.Write("Podaj imie: ");
            string imie = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            string nazwisko = Console.ReadLine();

            decimal saldo = pobierzLiczbeDecimal("Podaj saldo początkowe: ");
            int pin = pobierzLiczbeInt("Podaj pin: ");
                        
            return new Konto(new Osoba(imie,nazwisko),saldo,pin);
        }

        public static void Wplac(this Konto k)
        {
            decimal kwota = pobierzLiczbeDecimal("Podaj kwotę, którą chcesz wpłacić: "); ;
            k.DokonajWplaty(kwota);
        }

        public static void Wyplac(this Konto k)
        {
            decimal kwota = pobierzLiczbeDecimal("Podaj kwotę, którą chcesz wypłacić: "); 
            int pin = pobierzLiczbeInt("Podaj pin: ");
            if (k.DokonajWyplaty(kwota,pin))
            {
                Console.WriteLine("Proszę przejśc do kasy po pieniądze");
            }
            else
            {
                Console.WriteLine("Niestety, ta operacja nie może być wykonana");
            }           
        }

        public static void WypiszInformacjeOKoncie(this Konto k)
        {
            int pin = pobierzLiczbeInt("Podaj pin: ");
            Console.WriteLine(k.PobierzInformacje(pin));
            Console.WriteLine("Informacja dla konta o numerze: {0}", k.NumerKonta);            
        }
        
        public static void ZmienPin2(this Konto k)
        {
            int stary = pobierzLiczbeInt("Podaj stary pin: ");
            int nowy = pobierzLiczbeInt("Podaj nowy pin: ");
            int nowy2 = pobierzLiczbeInt("Powtórz nowy pin: ");
            if (nowy == nowy2)
            {
                if(k.ZmienPin(nowy, stary) )
                {
                    Console.WriteLine("Hasło zostało zmienione");
                    return;
                }                
            }
            Console.WriteLine("Wprowadzone piny są niezgodne");     
        }

        public static void ZmienHaslo()
        {
            Console.Write("Podaj stare hasło: ");
            string stare = Console.ReadLine();
            Console.Write("Podaj nowe hasło: ");
            string nowe = Console.ReadLine();
            Console.Write("Powtórz nowe hasło: ");
            string nowe2 = Console.ReadLine();
            if (nowe == nowe2)
            {
                if (Konto.ZmienHaslo(stare, nowe))
                {
                    Console.WriteLine("Hasło zostało zmienione");
                    return;
                }                
            }
            Console.WriteLine("Wprowadzone hasła są niezgodne");
        }

        public static void WypiszDebet()
        {
            Console.WriteLine("Aktualny maksymalny debet na koncie wynosi {0}", Konto.Debet);
        }
        public static void WypiszOprocentowanie()
        {            
            Console.WriteLine("Aktualne oprtocentowaniekont wynosi {0}", Konto.Oprocentowanie);
        }
        public static void ZmienOprocentowanie()
        {
            Console.Write("Podaj hasło: ");
            string haslo = Console.ReadLine();
            decimal oprocentowanie = pobierzLiczbeDecimal("Podaj nowe oprocentowanie: ");
            if (Konto.ZmienOprocentowanie(haslo, oprocentowanie))
            {
                Console.WriteLine("Oprocentowanie zostało zmienione");
            }
            else
            {
                Console.WriteLine("Operacja została anulowana");

            }
        }

        public static void ZmienMaksymalnyDebet()
        {
            Console.Write("Podaj hasło: ");
            string haslo = Console.ReadLine();
            decimal maxDebet = pobierzLiczbeDecimal("Podaj nowy maksymalny dopuszcalny debet: ");
            if (Konto.ZmienDebet(haslo, maxDebet))
            {
                Console.WriteLine("Maksymalny dopuszczalny ddenet został zmieniony");
            }
            else
            {
                Console.WriteLine("Operacja została anulowana");

            }
        }

    }
}
