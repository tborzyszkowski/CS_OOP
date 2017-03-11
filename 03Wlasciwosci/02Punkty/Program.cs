using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Punkty {
    public class Punkt {
        int x = 1;
        int y = 2;

        public int this[string nazwaWsp]
        {
            get
            {
                if (nazwaWsp == "x")
                    return x;
                else if (nazwaWsp == "y")
                    return y;
                else return x + y;
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            Punkt p = new Punkt();
            Console.WriteLine("x = {0}\ny = {1}\ncos = {2}", p["x"], p["y"], p["z"]);
        }
    }
}
