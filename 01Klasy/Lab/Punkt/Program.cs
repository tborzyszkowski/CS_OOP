using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punkt {
	class Program {
		static void Main(string[] args) {
			Punkt p1 = new Punkt(1, 0);
			Punkt p2 = new Punkt(2, 0);

			Console.WriteLine(p1);
			Console.WriteLine(p2);
			Console.WriteLine(p1.Odleglosc());
			Console.WriteLine(p2.Odleglosc());
			Console.WriteLine(p1.OdlegloscDwa(p2));

			Console.WriteLine(new Punkt(0, 0).IsTiangle(p1, p2));
		}
	}
}
