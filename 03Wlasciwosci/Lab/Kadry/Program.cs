using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadry
{
    class Program
    {
        static void Main(string[] args)
        {
            OsobaDlaKonsoli os1 = new OsobaDlaKonsoli();
            Console.WriteLine();
            os1.ZmienAdres();
            Console.WriteLine();
            os1.ZmienNazwisko();
            Console.WriteLine("\n***************\n");
            os1.WypiszOsobe();
            Console.WriteLine("\n***************\n");

            Osoba osoba2 = new Osoba(123, 1990, "Anna", "Kowalsa", 12, 23, "Kwiatowa", "97-350", "Piotrków Tryb.");
            os1.Osoba = osoba2;
            os1.ZmienAdres();
            Console.WriteLine(); 
            os1.ZmienNazwisko();
            Console.WriteLine("\n***************\n");
            os1.WypiszOsobe();

            Console.ReadKey();
        }
    }
}
