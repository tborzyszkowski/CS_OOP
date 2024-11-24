using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01MetodyGeneryczne
{

	class Program
	{
		public static void Swap<T>(ref T a, ref T b)
		{
			//T tmp = a;
			//a = b;
			//b = tmp;
            (a, b) = (b, a);
        }
		public static T Max<T>(T a, T b) where T : IComparable
		{
			return a.CompareTo(b) > 0 ? a : b;
		}

		static void Main(string[] args)
		{
			int a = 1, b = 2;

			Console.WriteLine($"Przed: a = {a}, b = {b}");
			Swap<int>(ref a, ref b);
			Console.WriteLine($"Po:    a = {a}, b = {b}");

			string s1 = "Ala", s2 = "Ola";
			Console.WriteLine($"Przed: s1 = {s1}, s2 = {s2}");
			Swap<string>(ref s1, ref s2);
			Console.WriteLine($"Po:    s1 = {s1}, s2 = {s2}");

			Console.WriteLine($"Max(a, b)   = {Max<int>(a, b)}");
			Console.WriteLine($"Max(s1, s2) = {Max<string>(s1, s2)}");
		}
	}
}
