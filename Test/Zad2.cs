using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2A {
    delegate bool Compare(int i, int j);
    delegate int Delegacja(int i, int j);
    class A {
        public event Delegacja SieDzieje;
        public int x = 1;
        public void DoRoboty(int i) {
            if (SieDzieje != null)
                x += SieDzieje(x, i);
            else x += 2 ;
        }
    }
    class Zad2 {
        static void Main(string[] args) {
            A a = new A();
            a.DoRoboty(2);
            Console.WriteLine("{0}", a.x);
            Compare   w   = (x, y) => (x < y);
            Delegacja fst = (x, y) => (w(x, y) ? x + y : x - y);
            a.SieDzieje += fst;
            a.DoRoboty(3);
            Console.WriteLine("{0}", a.x);
            a.SieDzieje += (x, y) => {
                Console.WriteLine((w(x, y) ? "A {0}" : "B {0}"), ++a.x);
                return 1 + x;
            };
            a.DoRoboty(4);
            Console.WriteLine("{0}", a.x);
            a.SieDzieje -= fst;
            a.DoRoboty(a.x);
            Console.WriteLine("{0}", a.x);
            Console.ReadKey();
        }
    }

}
