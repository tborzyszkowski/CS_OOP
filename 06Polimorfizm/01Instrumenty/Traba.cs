using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Instrumenty {
    class Traba : Instrument {
        public Traba() {
            this.waga = 2;
        }
        public new void Graj1() {
            Console.WriteLine("Graj1: Tra ta ta, tra ta ta");
        }
        public override void Graj2() {
            Console.WriteLine("Graj2: Tra ta ta, tra ta ta");
        }
        public void Dmuchaj() {
            Console.WriteLine("Dmuchaj: fju, fju");
        }
    }
}
