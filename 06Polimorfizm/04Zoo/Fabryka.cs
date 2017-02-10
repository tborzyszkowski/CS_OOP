using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Zoo {
    static class Fabryka {
        public static Zwierze Utworz(int i) {
            Zwierze zwierze = null;
            switch (i) {
                case 1:
                    zwierze = new Zwierze();
                    break;
                case 2:
                    zwierze = new Owca();
                    break;
                case 3:
                    zwierze = new Osiol();
                    break;
                case 4:
                    zwierze = new WilkZaadoptowany();
                    break;
            }
            return zwierze;
        }

        public static int Menu() {
            Console.Clear();
            Console.WriteLine("\n\t\t\t1 - Informacje ogólne o zwierzętach");
            Console.WriteLine("\n\t\t\t2 - Informacje o owcy");
            Console.WriteLine("\n\t\t\t3 - Informacje o osłach");
            Console.WriteLine("\n\t\t\t4 - Informacje o wilkach");
            Console.WriteLine("\n\t\t\t0 - Koniec");
            int i;
            bool b;
            do {
                do {
                    b = int.TryParse(Console.ReadLine(), out i);
                } while (!b);
            } while (0 > i || i > 4);
            return i;
        }
    }
}
