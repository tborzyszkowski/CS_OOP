using System;

namespace _01Zespolone
{
	class MyApp
	{
		static void Main(string[] args)
		{
			Zespolona z1 = new Zespolona(10, 12);
			Zespolona z2 = z1 + -2;
			Console.WriteLine($"{z1}");
			Console.WriteLine($"{z2}");

			double x = 20;
			Zespolona z3 = x + 30.5;
			Console.WriteLine($"{z3}");
			Console.WriteLine($"{(double)z3}");
			Console.WriteLine($"{(int)z3}");
		}
	}
}
