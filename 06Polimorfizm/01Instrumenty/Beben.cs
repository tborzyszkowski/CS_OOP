using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Instrumenty {
    class Beben : Instrument {
        public new void Graj1() {
            Console.WriteLine("Bum bum bum");
        }
        public override void Graj2() {
            Console.WriteLine("Bum bum bum");
        }
    }
}
