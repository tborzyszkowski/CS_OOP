using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Macierze;

namespace TestMacierzy
{
    static class MacierzDlaKonsoli
    {
        public static void WypiszMacierz(this Macierz a)
        {
            Console.Write("[ ");
            for (int i = 1; i <= a.LiczbaWierszy; i++)
            {
                Console.Write("<");
                for (int j = 1; j <= a.LiczbaKolumn; j++)
                {
                    Console.Write(a[i, j]);
                    if (j != a.LiczbaKolumn)
                        Console.Write("; ");
                }
                Console.Write("> ");
            }
            Console.Write("]");
        }
        private static Random generator = new Random();
        public static void InicjalizujMacierz(this Macierz a)
        {
           
            for (int i = 1; i <= a.LiczbaWierszy; i++)
            {                
                for (int j = 1; j <= a.LiczbaKolumn; j++)
                {
                    a[i,j] = generator.Next(0,11);
                }
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Macierz a = new Macierz(3, 2), b = new Macierz(3, 2);
            a.InicjalizujMacierz();
            Console.WriteLine("Macierz A: ");
            a.WypiszMacierz();
            Console.WriteLine("\nMacierz B: ");
            b.InicjalizujMacierz();
            b.WypiszMacierz();
            Console.WriteLine("\nMacierz A + B: ");
            (a + b).WypiszMacierz();
            Console.WriteLine("\nMacierz A - B: ");
            (a - b).WypiszMacierz();
            Console.WriteLine("\nMacierz 2 * A: ");
            (2*a).WypiszMacierz();
            Macierz c = new Macierz(2, 1);
            c.InicjalizujMacierz();
            Console.WriteLine("\nMacierz C: ");
            c.WypiszMacierz();
            Console.WriteLine("\nMacierz A * C: ");
            (a * c).WypiszMacierz();
            Macierz d = (Macierz)33;
            Console.WriteLine("\nMacierz D: ");
            d.WypiszMacierz();
            Console.ReadKey();

        }
    }
}
