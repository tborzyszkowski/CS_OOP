using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Punkty
{
	public class Punkt
	{
		private int x = 1;
		private int y = 2;

		public int this[string nazwaWsp] {
			get {
				if (nazwaWsp == "x")
					return x;
				if (nazwaWsp == "y")
					return y;
				return x + y;
			}
			set {
				if (nazwaWsp == "x")
					x = value;
				else if (nazwaWsp == "y")
					y = value;
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Punkt p = new Punkt();
			Console.WriteLine($"x = {p["x"]}\ny = {p["y"]}\nz = {p["z"]}");
			p["x"] = 10;
			p["y"] = 20;
			p["z"] = 3000;
			Console.WriteLine($"x = {p["x"]}\ny = {p["y"]}\nz = {p["z"]}");
		}
	}
}
