using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Zoo {
    class Klient {
        private Zwierze zwierze;
        public int Menu() {
            Console.WriteLine("Twój aktualkny wybór to {0}\n", zwierze);
            Console.WriteLine("1 - Dżwięki wydawane przez zwierzę");
            Console.WriteLine("2 - Nazwa łacińska");
            Console.WriteLine("3 - Powrót do menu główne");
            int i;
            bool b;
            do {
                b = int.TryParse(Console.ReadLine(), out i);
            } while (!b);
            return i;
        }
        public void Uruchom() {
            int i, j;
            while (true) {
                i = Fabryka.Menu();
                if (i == 0)
                    break;
                zwierze = Fabryka.Utworz(i);
                do {
                    j = Menu();
                    Console.Clear();
                    switch (j) {
                        case 1:
                            zwierze.WydajGlos();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine(zwierze.NazwaLacinska);
                            Console.ReadKey();
                            break;
                    }
                } while (j != 3);
            }
        }

        static void Main(string[] args) {
            Klient k = new Klient();
            k.Uruchom();
        }
    }
}
