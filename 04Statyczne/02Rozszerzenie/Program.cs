using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Rozszerzenie {
	static class RozszerzenieTypuDouble {
		public static double Potega(this double x, int n) {
			double iloczyn = 1;
			for (int i = 0; i < (n > 0 ? n : -n); i++)
			{
				iloczyn *= x;
			}
			if (n < 0)
				return 1 / iloczyn;
			return iloczyn;
		}
		public static Type GetType(this double x, int a) {
			return ((int)(x)).GetType();
		}
	}

	class Program {
		static void Main(string[] args) {
			double x = 10;
			Console.WriteLine($"{x} do potęgi drugiej: {x.Potega(2).Potega(2)}");
			Console.WriteLine($"10 do potęgi minus drugiej: {(10.0).Potega(-2).Potega(-1)}");
			Type z = x.GetType(2);
			Console.WriteLine(z);

		}
	}
}
