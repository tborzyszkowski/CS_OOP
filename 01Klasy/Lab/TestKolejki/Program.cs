using System;
using System.Collections.Generic;
using System.Text;

using KolejkaFIFO;

namespace TestKolejki
{
    class Program
    {
        static char Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tA - Dodaj napis do kolejki");
            Console.WriteLine("\n\t\tB - Usuñ napis z kolejki");
            Console.WriteLine("\n\t\tC - Podaj liczbê elementów w kolejce");
            Console.WriteLine("\n\t\tD - Wyczyœæ kolejkê");
            Console.WriteLine("\n\t\tK - Koniec");
            return Console.ReadKey(true).KeyChar;

        }
        static void Main(string[] args)
        {
            Queue mojaKolejka = new Queue();
            mojaKolejka.Create(10);
            string tmp;
            char c;

            do
            {
                c = Menu();
                switch (c)
                {
                    case 'a':
                    case 'A':
                        Console.Write("Podaj napis który ma byæ dodany do kolejki: ");
                        tmp = Console.ReadLine();
                        mojaKolejka.Enqueue(tmp);
                        break;
                    case 'b':
                    case 'B':
                        Console.WriteLine("Nappis wyjêty z kolejki: {0}", mojaKolejka.Dequeue());
                        Console.ReadKey();
                        break;
                    case 'c':
                    case 'C':
                        Console.WriteLine("Liczba elementów w kolejce wynosi: {0}", 
                            mojaKolejka.GetLength());
                        Console.ReadKey();
                        break;
                    case 'd':
                    case 'D':
                        mojaKolejka.Clear();
                        Console.WriteLine("Kolejka wyczyszczona!!!");
                        Console.ReadKey();
                        break;
                }
            }
            while (!(c == 'k' || c == 'K'));
        }
    }
}
