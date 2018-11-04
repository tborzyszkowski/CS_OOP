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
            Console.WriteLine("Traba.Graj1: Tra ta ta, tra ta ta");
        }
        public override void Graj2() {
            Console.WriteLine("Traba.Graj2: Tra ta ta, tra ta ta");
        }
        public void Dmuchaj() {
            Console.WriteLine("Traba.Dmuchaj: fju, fju");
        }
    }
}
