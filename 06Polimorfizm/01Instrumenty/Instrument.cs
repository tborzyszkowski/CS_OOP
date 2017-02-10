using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Instrumenty {
    class Instrument {
        public void Graj1() {
            Console.WriteLine("Cisza");
        }
        public virtual void Graj2() {
            Console.WriteLine("Cisza 2!!!");
        }
    }
}
