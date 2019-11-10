using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Zoo
{
	class WilkZaadoptowany : Zwierze
	{
		private Wilk wilk = new Wilk();
		public override void WydajGlos()
		{
			Console.WriteLine(wilk.Wyj());
		}
		public override string NazwaLacinska => wilk.PodajNazweLacinska();

		public override string ToString()
		{
			return "wilk";
		}
	}
}
