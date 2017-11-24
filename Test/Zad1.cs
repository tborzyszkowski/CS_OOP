using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1A {
    class A {
        private int q = 33;
        public int Q
        {
            get { return q / 2; }
            set { q = value + 2; }
        }
        public int this[int i]
        {
            get { return Q + i; }
            set { Q = value + i; }
        }
    }
    class Zad1 {
        static void Main() {
            A a = new A { Q = 11 };
            a[2] = 3;
            Console.WriteLine("{0}", a.Q);
            Console.WriteLine("{0} {1}", a[1], a[2]);
            a[1] = a[2];
            Console.WriteLine("{0} {1}", a[1], a[2]);
        }
    }
}
