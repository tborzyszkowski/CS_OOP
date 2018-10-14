using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Punkt {
    class Punkt {
        public double X = 0, Y = 0;

        public void Wypisz() {
            Console.WriteLine($"({X}, {Y})");
        }
    }
    class Program {
        static void Main(string[] args) {
            Punkt p1 = new Punkt();
            Punkt p2 = new Punkt();

            p1.X = 3;
            p1.Y = 4;
            p2.X = 10;
            p2.Y = 20;

            p1.Wypisz();
            p2.Wypisz();

        }
    }
}
