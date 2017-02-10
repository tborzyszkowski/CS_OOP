using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Interfejs {
    interface IWymaganie {
        int funkcja(int n);
    }

    class Obliczenie1 : IWymaganie {
        public int funkcja(int n) {
            return n + 1;
        }
    }

    class Obliczenie2 : IWymaganie {
        public int funkcja(int n) {
            return n - 1;
        }
    }

    class Program {
        static int mojeObliczenie(IWymaganie w, int n) {
            return w.funkcja(w.funkcja(n));
        }
        static void Main(string[] args) {
            IWymaganie w;
            Obliczenie1 o1 = new Obliczenie1();
            Obliczenie2 o2 = new Obliczenie2();

            w = o1;
            Console.WriteLine("w: {0}", w.funkcja(1));
            w = o2;
            Console.WriteLine("w: {0}", w.funkcja(1));

            Console.WriteLine("mojeObliczenie(o1, 1): {0}", mojeObliczenie(o1, 1));
            Console.WriteLine("mojeObliczenie(o2, 1): {0}", mojeObliczenie(o2, 1));

        }
    }
}
