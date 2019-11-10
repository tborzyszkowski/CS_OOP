using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01PolePowierzchni
{
	public struct PolePowierzchni
	{
		public PolePowierzchni(double metrKwadratowy)
			: this()
		{
			MetrKwadratowy = metrKwadratowy;
		}

		public double MetrKwadratowy { set; get; }
		public double Ar {
			set { MetrKwadratowy = 100 * value; }
			get { return MetrKwadratowy / 100; }
		}
		public double Hektar {
			set { MetrKwadratowy = 10000 * value; }
			get { return MetrKwadratowy / 10000; }
		}
	}
	class Pole
	{
		static void Main(string[] args)
		{
			PolePowierzchni p1 = new PolePowierzchni(1000);
			Console.WriteLine($"Ar = {p1.Ar}, Hektar = {p1.Hektar}, M2 = {p1.MetrKwadratowy}");
			p1.Ar = 7;
			Console.WriteLine($"Ar = {p1.Ar}, Hektar = {p1.Hektar}, M2 = {p1.MetrKwadratowy}");
			Console.ReadKey();
		}
	}
}
