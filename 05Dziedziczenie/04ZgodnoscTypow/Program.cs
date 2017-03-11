using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04ZgodnoscTypow {
    class A {
        public int x;
        public void setA(int x) {
            this.x = x;
        }
    }
    class B : A {
        public int x;
        public void setB(int a, int b) {
            this.x = a;
            base.x = b;
        }
        public string zawartosc() {
            return string.Format("B: x = {0}, base.x = {1}", x, base.x);
        }
    }
    class Program {
        static void Main(string[] args) {
            A pa = new A();
            B pb = new B();

            pa.setA(5);
            pb.setB(15, 16);

            Console.WriteLine("A: pa.x = {0}", pa.x);
            Console.WriteLine(pb.zawartosc());
            Console.WriteLine(pa.GetType());
            Console.WriteLine(pb.GetType());
            Console.WriteLine();
            pa = pb;
            //pb = pa;

            Console.WriteLine("A: pa.x = {0}", pa.x);
            Console.WriteLine(pb.zawartosc());
            Console.WriteLine(pa.GetType());
            Console.WriteLine(pb.GetType());

            B pb2 = (B)pa;
            Console.WriteLine(pb2.zawartosc());
            Console.WriteLine(pb2.GetType());
        }
    }
}
