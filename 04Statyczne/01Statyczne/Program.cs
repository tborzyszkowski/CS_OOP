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
		public void wypisz() {
			Console.WriteLine($"a = {a}, b = {b}");
		}
	}
	class Program {
		static void Main(string[] args) {
			Console.WriteLine($"Pierwsza.a = {Pierwsza.a}");

			Pierwsza p = new Pierwsza(2, 3);
			p.wypisz();
			Console.WriteLine($"Pierwsza.a = {Pierwsza.a}");

			Pierwsza.a = 19;
			p.wypisz();
			Console.WriteLine($"Pierwsza.a = {Pierwsza.a}");

			Pierwsza q = new Pierwsza(12, 13);
			q.wypisz();
			p.wypisz();
			Console.WriteLine($"Pierwsza.a = {Pierwsza.a}");
		}
	}
}
