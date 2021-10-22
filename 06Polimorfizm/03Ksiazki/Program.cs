using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Ksiazki {
	class Program {
		static void Main(string[] args) {
			Ksiazka k1 = new Ksiazka("Aleksander", "Fredro", "Zemsta"),
				k2 = new Ksiazka("Aleksander", "Fredro", "Zemsta"),
				k3 = new Ksiazka("Jan", "Kowalski", "ABC", 2000, "DEF", "123456"),
				k4 = new Ksiazka("Adam", "Kos", "XYZ", 2001, "QWERTY", "123456");

			Console.WriteLine($"{k1}\n{k2}\n{k3}\n{k4}");
			Console.WriteLine($"k1 = k2 {k1.Equals(k2)}");
			Console.WriteLine($"k3 = k4 {k3.Equals(k4)}");

			Console.WriteLine($"GetHashCode: {k1.GetHashCode()}");
			Console.WriteLine($"ToString: {k1}");
			Console.WriteLine($"GetHashCode: {k2.GetHashCode()}");
			Console.WriteLine($"ToString: {k2}");
			Console.WriteLine($"GetHashCode: {k3.GetHashCode()}");
			Console.WriteLine($"ToString: {k3}");
		}
	}
}
