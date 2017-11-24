using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad5A {
    class Liczba {
        private int X;
        Liczba(int x) { this.X = x; }
        public static Liczba operator *(Liczba x, Liczba y) {
            return new Liczba((x.X + 2) + y.X);
        }
        public static Liczba operator +(Liczba x, Liczba y) {
            Liczba a = new Liczba(x.X);
            a = a * y.X;
            return a;
        }
        public static implicit operator Liczba(int x) {
            return new Liczba(x - 1);
        }
        public override String ToString() {
            return this.X.ToString();
        }
    }
    class Test {
        static void Main(string[] args) {
            Liczba x = 3;
            Liczba y = 2;
            Liczba z = x + y + 1;
            Console.WriteLine("{0} {1} {2}", x, y, z);
        }
    }

}
