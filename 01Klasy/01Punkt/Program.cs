using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Punkt {
    class Punkt {
        public double X = 0, Y = 0;

        public double dist(Punkt p) {
            return Math.Sqrt((this.X - p.X) * (this.X - p.X) + (this.Y - p.Y) * (this.Y - p.Y));
        }

        public override String ToString() {
            return $"({X}, {Y})";
        }
    }
    class Program {
        static void Main(string[] args) {
            Punkt p1 = new Punkt();
            Punkt p2 = new Punkt();

            p1.X = 0;
            p1.Y = 0;
            p2.X = 1;
            p2.Y = 1;

            Console.WriteLine($"[{p1}, {p2}] = {p1.dist(p2)}");
        }
    }
}
