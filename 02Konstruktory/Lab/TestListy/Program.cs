using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestListy
{
    class Program
    {
        static void Main(string[] args)
        {
            Listy.List orygianal = new Listy.List();
            orygianal.AddToHead("Ania");
            orygianal.AddToHead("Agnieszka");
            orygianal.AddToHead("Wiktoria");
            orygianal.AddToHead("Kasia");

            Listy.List kopiaR = orygianal.KlonujRekurencyjnie();
            Listy.List kopiaI = orygianal.KlonujIteracyjnie();

            Console.WriteLine("Wypisujemy przed modyfikacjami: ");
            Console.WriteLine("\n***Oryginał: ");
            orygianal.PrintAll();
            Console.WriteLine("\n***Kopia R: ");
            kopiaR.PrintAll();
            Console.WriteLine("\n***Kopia I: ");
            kopiaI.PrintAll();
            
            Console.WriteLine("\nModyfikujemy:");
            Console.ReadKey();
            kopiaR.AddToHead("Zosia");
            kopiaR.AddToHead("Jola");
            kopiaI.DeleteFromHead();
            kopiaI.DeleteFromHead();
            
            Console.WriteLine("\n***Oryginał: ");
            orygianal.PrintAll();
            Console.WriteLine("\n***Kopia R: ");
            kopiaR.PrintAll();
            Console.WriteLine("\n***Kopia I: ");
            kopiaI.PrintAll();
            Console.ReadKey();
        }
    }
}
