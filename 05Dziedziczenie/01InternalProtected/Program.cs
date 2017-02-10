using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outside;

namespace _01InternalProtected {
    //class Wewnetrzna {
    //    internal void g() {
    //        Zewnetrzna z = new Zewnetrzna();
    //        z.f();
    //        Console.WriteLine("InternalProtected.Wewnetrzna.g()");
    //    }
    //}
    class Wewnetrzna : Zewnetrzna {
        internal void g() {
            f();
            Console.WriteLine("InternalProtected.Wewnetrzna.g()");
        }
    }
    class Program {
        static void Main(string[] args) {
            Wewnetrzna w = new Wewnetrzna();
            w.g();
        }
    }

}
