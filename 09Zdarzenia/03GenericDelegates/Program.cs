using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericDelegates {
    class GenDelegates {
        public Action<int> IterAction;
        public Func<int, int, bool> Relation;
        public Predicate<int> Proprety;

        public void IterOne(int n) {
            for (int i = 0; i < n; i++) Console.WriteLine(i);
        }
        public void IterTwo(int n) {
            for (int i = 0; i < n; i++) Console.WriteLine(2 * i);
        }
        public bool RelSample1(int x, int y) {
            return x < y;
        }
        public bool PropEven(int n) {
            return n % 2 == 0;
        }
    }
    class Test { 
        static void Main(string[] args) {
            GenDelegates gd = new GenDelegates();
            gd.IterAction += gd.IterOne;

            gd.IterAction(6);
            gd.IterAction -= gd.IterOne;
            gd.IterAction += gd.IterTwo;
            gd.IterAction(6);

            gd.Relation += gd.RelSample1;
            Console.WriteLine(gd.Relation(1, 2));
            gd.Relation -= gd.RelSample1;
            gd.Relation += (x, y) => x + y < 3;
            Console.WriteLine(gd.Relation(1, 2));

            gd.Proprety += gd.PropEven;
            Console.WriteLine(gd.Proprety(3));
            gd.Proprety -= gd.PropEven;
            gd.Proprety += x => x % 2 == 1;
            Console.WriteLine(gd.Proprety(3));
            }
    }
}
