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
            Listy.List imiona = new Listy.List();
            imiona.AddToHead("Ania");
            imiona.AddToHead("Agnieszka");
            imiona.AddToHead("Wiktoria");
            imiona.AddToHead("Kasia");

            for (int i = 0; i < imiona.GetCount(); i++)
            {
                Console.WriteLine("{0}. {1}", i, imiona[i]);
            }
            imiona[1] = "Basia";
            imiona[3] = "Ola";

            for (int i = 0; i < imiona.GetCount(); i++)
            {
                Console.WriteLine("{0}. {1}", i, imiona[i]);
            }
            Console.ReadKey();
        }
    }
}
