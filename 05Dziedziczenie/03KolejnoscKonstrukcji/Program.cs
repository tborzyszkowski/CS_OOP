using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03KolejnoscKonstrukcji {
    class AK {
        public AK(int i) {
            Console.WriteLine("Konstruktor z A: {0}", i);
        }
        public AK() {
            Console.WriteLine("Konstruktor z A()");
        }
    }
    class BK : AK
    {
        public BK(int i) : base(i+1) {
            Console.WriteLine("Konstruktor z B: {0}", i);
        }
        public BK() : base() {
            Console.WriteLine("Konstruktor z B()");
        }
    }
    class CK : BK {
        public CK(int i) : base(2 * i) {
            Console.WriteLine("Konstruktor z C: {0}", i);
        }
    }
    // klasa testujaca
    class KonstrDemo {
        static void Main(string[] args) {
            new CK(5);
        }
    }
}
