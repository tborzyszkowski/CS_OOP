using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04WczesnaImplementacja {
    interface Interface1 {
        void f();
    }
    class A {
        public void f() {
            Console.WriteLine("f() z A");
        }
    }
    class B : A, Interface1 {
    }

    class Program {
        static void Main(string[] args) {
            B b = new B();
            b.f();
            ((A)b).f();
            ((Interface1)b).f();
            A a = new A();
            Interface1 ii = b;
        }
    }
}
