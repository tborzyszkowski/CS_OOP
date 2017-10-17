using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Rozszerzenie {
    static class RozszerzenieTypuDouble {
        public static double PotegaCalkowita(this double x, int n) {
            double iloczyn = 1;
            for (int i = 0; i < (n > 0 ? n : -n); i++) {
                iloczyn *= x;
            }
            if (n < 0)
                return 1 / iloczyn;
            return iloczyn;
        }
    }

    class Program {
        static void Main(string[] args) {
            double x = 10;
            Console.WriteLine("{0} do potęgi drugiej: {1}", x, x.PotegaCalkowita(2).PotegaCalkowita(2));
            Console.WriteLine("{0} do potęgi minus drugiej: {1}", 10, (10.0).PotegaCalkowita(-2).PotegaCalkowita(-1));
            Console.ReadKey();
        }
    }
}
