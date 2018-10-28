using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jednostki {
    class Program {
        static void Main(string[] args) {
            ILength dlugosci = new Jednostki();
            IQuantity ilosci = new Jednostki();

            dlugosci.Metr = 10;
            (dlugosci as IQuantity).Sztuka = 600;
            Console.WriteLine((dlugosci as IQuantity).Kopa);
        }
    }
}
