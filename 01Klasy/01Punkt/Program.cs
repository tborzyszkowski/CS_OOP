using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Punkt {
    class Punkt {
        public double x = 0, y = 0;

        public void Wypisz() {
            Console.WriteLine("({0}, {1})", x, y);
        }
    }
    class Program {
        static void Main(string[] args) {
            Punkt p1 = new Punkt();
            Punkt p2 = new Punkt();

            p1.x = 3;
            p1.y = 4;
            p2.x = 10;
            p2.y = 20;

            p1.Wypisz();
            p2.Wypisz();

        }
    }
}
