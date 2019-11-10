using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02KolejnoscInicjalizacji
{
	class Pierwsza
	{
		public int x = 10;

		public Pierwsza() : this(11)
		{
		}
		public Pierwsza(int x) => this.x = x;
	}

	class Druga
	{
		public int Y;
		public Pierwsza P = new Pierwsza();
		public Druga()
		{
			this.Y = 11;
			this.P = new Pierwsza(101);
		}
		public Druga(int y)
		{
			this.Y = y;
			this.P = new Pierwsza(2 * y);
		}

	}
	class Program
	{
		static void Main(string[] args)
		{
			Pierwsza p1 = new Pierwsza { x = 5 };
			Druga d1 = new Druga() { P = new Pierwsza() { x = 6 }, Y = 33 };

			Console.WriteLine($"p1.x = {p1.x}");
			Console.WriteLine($"d1.y = {d1.Y}, d1.p.x = {d1.P.x}");
			Console.WriteLine();

			Pierwsza p2 = new Pierwsza(45) { x = -1 };
			Druga d2 = new Druga(55) { P = new Pierwsza(13), Y = 44 };

			Console.WriteLine($"p2.x = {p2.x}");
			Console.WriteLine($"d2.y = {d2.Y}, d2.p.x = {d2.P.x}");
		}
	}
}
