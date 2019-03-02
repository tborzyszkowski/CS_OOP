using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punkt
{
    class Program
    {
        static void Main(string[] args)
        {
            Punkt p1 = new Punkt(1, 1);
            Punkt p2 = new Punkt(2, 2);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p1.Odleglosc());
            Console.WriteLine(p2.Odleglosc());
            Console.WriteLine(p1.OdlegloscDwa(p2));
        }
    }
}
