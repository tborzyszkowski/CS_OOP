using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Instrumenty {
    class Beben : Instrument {
        public Beben() {
            this.waga = 3;
        }
        public new void Graj1() {
            Console.WriteLine("Graj1:Bum bum bum");
        }
        public override void Graj2() {
            Console.WriteLine("Graj2: Bum bum bum");
        }
    }
}
