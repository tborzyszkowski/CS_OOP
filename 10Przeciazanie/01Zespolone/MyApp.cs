using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Zespolone {
    class MyApp {
        static void Main(string[] args) {
            Zespolona z1 = new Zespolona(10, 12);
            Zespolona z2 = z1 + -2;
            Console.WriteLine("{0} {1}", z2.Re, z2.Im);

            double x = 20;
            Zespolona z3 = x + 30;
            Console.WriteLine("{0} {1}", z3.Re, z3.Im);
            Console.WriteLine("{0}", (double)z3);

            Console.ReadKey();

        }
    }
}
