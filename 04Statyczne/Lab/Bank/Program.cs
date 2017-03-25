using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Konto k1 = KontoDlaKonsoli.UtworzKonto();
            k1.Wplac();
            k1.Wyplac();
            k1.WypiszInformacjeOKoncie();
            k1.ZmienPin2();

            KontoDlaKonsoli.WypiszDebet();
            KontoDlaKonsoli.WypiszOprocentowanie();
            KontoDlaKonsoli.ZmienHaslo();
            KontoDlaKonsoli.ZmienMaksymalnyDebet();
            KontoDlaKonsoli.ZmienOprocentowanie();

            Console.ReadKey();

        }
    }
}
