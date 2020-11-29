using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Statyczne {
	class Pierwsza {
		public static int a = 1;
		public int b = 2;

		public Pierwsza(int x, int y) {
			a += x;
			b += y;
		}
		static Pierwsza() {
			a++;
			//b++;
		}
		public override string ToString() {
			return $"a = {a}, b = {b}";
		}
	}
	class Program {
		static void Main(string[] args) {
			Console.WriteLine($"Pierwsza.a = {Pierwsza.a}");

			Pierwsza p = new Pierwsza(2, 3);

			Console.WriteLine(p);
			Console.WriteLine($"Pierwsza.a = {Pierwsza.a}");

			Pierwsza.a = 19;
			Console.WriteLine(p);
			Console.WriteLine($"Pierwsza.a = {Pierwsza.a}");

			Pierwsza q = new Pierwsza(12, 13);
			Console.WriteLine(q);
			Console.WriteLine(p);
			Console.WriteLine($"Pierwsza.a = {Pierwsza.a}");
		}
	}
}
