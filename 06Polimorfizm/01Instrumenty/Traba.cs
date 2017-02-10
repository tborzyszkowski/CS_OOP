using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Instrumenty {
    class Traba : Instrument {
        public new void Graj1() {
            Console.WriteLine("Tra ta ta, tra ta ta");
        }
        public override void Graj2() {
            Console.WriteLine("Tra ta ta, tra ta ta");
        }
    }
}
