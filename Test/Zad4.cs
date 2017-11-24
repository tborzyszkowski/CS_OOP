using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4A {
    public class A {
        public static int a = 1;
        public int g() { return a; }
        public virtual int h() { a--; return g(); }
    }
    class B : A {
        int b = 2;
        public new virtual int g() { a += b; return base.g(); }
        public override int h() { b += a; return this.g(); }

    }
    class C : B {
        public override int g() { return base.g(); }
    }
    class Test {
        static void Main(string[] args) {
            A a = new A(); B b = new B(); C c = new C();
            Console.WriteLine("A: {0} {1}", a.g(), a.h() );
            Console.WriteLine("B: {0} {1}", b.g(), b.h() );
            Console.WriteLine("C: {0} {1}", c.g(), c.h());
        }
    }
}
