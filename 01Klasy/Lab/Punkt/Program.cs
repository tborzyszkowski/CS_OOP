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
            Punkt p1 = new Punkt();
            Punkt p2 = new Punkt();

            p1.x = 3;
            p1.y = 4;
            p2.x = 10;
            p2.y = 20;

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p1.Odleglosc());
            Console.WriteLine(p2.Odleglosc());
        }
    }
}
