using System;

namespace _02Interfejs {
	interface IWymaganie {
		int Funkcja(int n);
	}

	class Obliczenie1 : IWymaganie {
		public int Funkcja(int n) {
			return n + 1;
		}
	}

	class Obliczenie2 : IWymaganie {
		public int Funkcja(int n) {
			return n - 1;
		}
	}

	class Program {
		static int MojeObliczenie(IWymaganie w, int n) {
			return w.Funkcja(w.Funkcja(n));
		}
		static void Main(string[] args) {
			IWymaganie w;
			Obliczenie1 o1 = new Obliczenie1();
			Obliczenie2 o2 = new Obliczenie2();

			w = o1;
			Console.WriteLine("w: {0}", w.Funkcja(1));
			w = o2;
			Console.WriteLine("w: {0}", w.Funkcja(1));

			Console.WriteLine("mojeObliczenie(o1, 1): {0}", MojeObliczenie(o1, 1));
			Console.WriteLine("mojeObliczenie(o2, 1): {0}", MojeObliczenie(o2, 1));

		}
	}
}
