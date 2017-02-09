using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02KolejnoscInicjalizacji {
    class Pierwsza {
        public int x = 10;

        public Pierwsza() {
            this.x = 11;
        }
        public Pierwsza(int x) {
            this.x = x;
        }
    }

    class Druga {
        public int y = 20;
        public Pierwsza p = new Pierwsza();
        public Druga() {
            this.y = 11;
            this.p = new Pierwsza(101);
        }
        public Druga(int y) {
            this.y = y;
            this.p = new Pierwsza(2*y);
        }

    }
    class Program {
        static void Main(string[] args) {
            Pierwsza p1 = new Pierwsza() { x = 5 };
            Druga d1 = new Druga() { p = new Pierwsza(), y = 33 };

            Console.WriteLine("p1.x = {0}", p1.x);
            Console.WriteLine("d1.y = {0}, d1.p.x = {1}", d1.y, d1.p.x);
            Console.WriteLine();

            Pierwsza p2 = new Pierwsza(45) { x = -1 };
            Druga d2 = new Druga(55) { p = new Pierwsza(13), y = 44 };

            Console.WriteLine("p2.x = {0}", p2.x);
            Console.WriteLine("d2.y = {0}, d2.p.x = {1}", d2.y, d2.p.x);
        }
    }
}
