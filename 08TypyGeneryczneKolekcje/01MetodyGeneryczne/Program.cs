using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01MetodyGeneryczne {

    class Program {
        public static void Swap<T>(ref T a, ref T b) {
            T tmp = a;
            a = b;
            b = tmp;
        }
        public static T Max<T>(T a, T b) where T : IComparable {
            if (a.CompareTo(b) > 0)
                return a;
            return b;
        }

        static void Main(string[] args) {
            int a = 1, b = 2;

            Console.WriteLine("Przed: a = {0}, b = {1}", a, b);
            Swap<int>(ref a, ref b);
            Console.WriteLine("Po:    a = {0}, b = {1}", a, b);

            string s1 = "Ala", s2 = "Ola";
            Console.WriteLine("Przed: s1 = {0}, s2 = {1}", s1, s2);
            Swap<string>(ref s1, ref s2);
            Console.WriteLine("Po:    s1 = {0}, s2 = {1}", s1, s2);

            Console.WriteLine("Max(a, b)   = {0}", Max<int>(a, b));
            Console.WriteLine("Max(s1, s2) = {0}", Max<string>(s1, s2));
        }
    }
}
