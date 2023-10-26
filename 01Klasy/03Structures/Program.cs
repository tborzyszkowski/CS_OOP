using System;

namespace _03Structures {
	class Pierwsza {
		public int X = 0;
		//public static bool Addition(out int p, out int q) {
		//	p = 30;
		//	q = 40;
		//	p += p;
		//	q += q;
		//	return p > q;
		//}
	}

	struct First {
		public int X;
	}

	class Program {
		static void Main(string[] args) {
			Pierwsza p1 = new Pierwsza();
			p1.X = 5;
			Pierwsza p2 = p1;
			p2.X = 7;
			Console.WriteLine($"p1.x = {p1.X}, p2.x = {p2.X}");

			First f1 = new First();
			f1.X = 5;
			First f2 = f1;
			f2.X = 7;
			Console.WriteLine($"f1.x = {f1.X}, f2.x = {f2.X}");

			int x = 5;
			int y = x;
			y = 7;
			Console.WriteLine($"x = {x}, y = {y}");

			int pierwsza = 0, druga = 0;
			//bool result = Pierwsza.Addition(out pierwsza, out druga);
			//Console.WriteLine($"{result} - {pierwsza} - {druga}");

		}
	}
}
