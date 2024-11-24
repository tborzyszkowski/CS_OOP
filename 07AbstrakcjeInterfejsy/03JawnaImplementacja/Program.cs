﻿using System;
using System.Collections.Generic;


namespace _03JawnaImplementacja {
	interface IPilkarz {
		void Strzelaj();
	}
	interface IZolnierz {
		void Strzelaj();
	}
	class Postac : IZolnierz, IPilkarz {
		public void Strzelaj() {
			Console.WriteLine("Strzelam ogólnie");
		}
		void IPilkarz.Strzelaj() {
			int x = 1;
			Console.WriteLine($"Strzelam do bramki {x}");
		}
		void IZolnierz.Strzelaj() {
			int x = 2;
			Console.WriteLine($"Strzelam do celu {x}");
		}
	}
	class Program {
		static void Main(string[] args) {
			Postac p = new Postac();
			p.Strzelaj();
			//IPilkarz pp = new Postac();
			IPilkarz pp = p;
			pp.Strzelaj();
			//IZolnierz zp = new Postac();
			IZolnierz zp = p;
			zp.Strzelaj();
			pp.Strzelaj();

			p = null;
			(p as IPilkarz)?.Strzelaj();
			p = new Postac();
			(p as IZolnierz)?.Strzelaj();
			((p as IPilkarz) as IZolnierz)?.Strzelaj();
            p = null;
			if (p is null)//(p is Postac)
				p?.Strzelaj();
			if (p is HashSet<Postac>)
				p = null;
		}
	}
}
