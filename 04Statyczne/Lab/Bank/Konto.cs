using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Bank
{
    class Osoba
    {
        public string Imie { set; get; }
        public string Nazwisko { set; get; }
        public Osoba(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }
    }

    class Konto
    {
        private const string NAZWAPLIKU = "numer.dat";

        readonly private int numerKonta;
        public int NumerKonta
        {
            get { return numerKonta; }
        }
        private static int ostatniNumerKonta;

        static Konto()
        {
            if(File.Exists(NAZWAPLIKU))
            {
                BinaryReader br = null;
                try
                {
                    br = new BinaryReader(File.Open(NAZWAPLIKU,FileMode.Open));
                    ostatniNumerKonta = br.ReadInt32();
                }
                finally
                {
                    if(br != null)
                        br.Close();
                }
            }
            else
            {
                ostatniNumerKonta = 0;
            }
        }

        public Osoba Wlasciciel { set; get; }
        private decimal saldo;
        private int pin;

        public Konto(Osoba wlasciciel):this(wlasciciel,0,0)
        {            
        }

        public Konto(Osoba wlasciciel,decimal saldoPocztkowe,int pin)
        {
            Wlasciciel = wlasciciel;
            this.saldo = saldoPocztkowe;
            this.pin = pin;

            ostatniNumerKonta++;
            numerKonta = ostatniNumerKonta;
            BinaryWriter bw = null;
            try
            {
                bw = new BinaryWriter(File.Open(NAZWAPLIKU, FileMode.Create));
                bw.Write(ostatniNumerKonta);
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }
        }

        private static decimal oprocentowanie = 0.05m;
        public static decimal Oprocentowanie
        {
            get { return oprocentowanie; }
        }

        private static decimal debet = 1000;
        public static decimal Debet
        {
            get { return debet; }
        }
        private static string haslo = "P@ssw0rd";
        public static bool ZmienHaslo(string stareHaslo, string noweHaslo)
        {
            if (stareHaslo == haslo)
            {
                haslo = noweHaslo;
                return true;
            }
            return false;
        }

        public static bool ZmienDebet(string haslo, decimal nowyDebet)
        {
            if (Konto.haslo == haslo)
            {
                debet  = nowyDebet;
                return true;
            }
            return false;
        }

        public static bool ZmienOprocentowanie(string haslo, decimal nowyOprocentowanie)
        {
           if (Konto.haslo == haslo)
            {
                oprocentowanie = nowyOprocentowanie;
                return true;
            }
            return false;
        }        


        private bool SprawdzPin(int pin)
        {
            if (this.pin == pin)
                return true;
            return false;
        }



        public void DokonajWplaty(decimal kwota)
        {
            if (kwota < 0)
                throw new ArgumentException("Wpłacana kwota nie może być mniejsza od zera");
            saldo += kwota;
        }

        public bool DokonajWyplaty(decimal kwota, int pin)
        {
            if (!SprawdzPin(pin) || saldo + debet< kwota)
                return false;
            saldo -= kwota;
            return true;
        }

        public bool ZmienPin(int nowy, int stary)
        {
            if (SprawdzPin(stary))
            {
                pin = nowy;
                return true;
            }
            return false;
        }


        public string PobierzInformacje(int pin)
        {
            if (SprawdzPin(pin))
            {
                return string.Format("Pan(i) {0} {1} posiada na koncie: {2}",
                        Wlasciciel.Imie, Wlasciciel.Nazwisko, saldo);
            }
            return "Brak dostępu";
        }

    }
}
