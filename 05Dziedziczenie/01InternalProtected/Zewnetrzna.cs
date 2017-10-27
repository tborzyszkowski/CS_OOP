using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01InternalProtected{ 
    //Outside {
    class Zewnetrzna {
        internal  void fff() {
            Console.WriteLine("Outside.Zewnetrzna.f()");
        }
    }
}
