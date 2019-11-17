using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Base {
	abstract class NextBase {
		public abstract int Nastepny(int n);
		public int ZwiekszODwa(int n) {
			return Nastepny(Nastepny(n));
		}
	}
	class OJeden : NextBase {
		public override int Nastepny(int n) {
			return n + 1;
		}
	}
	class ODwa : NextBase {
		public sealed override int Nastepny(int n) {
			return n + 2;
		}
	}
	class ODwaRazyDwa : ODwa {
		//public override int Nastepny(int n) {
		//    return base.Nastepny(base.Nastepny(n));
		//}
	}

	class Program {
		static void Main(string[] args) {
			NextBase nb;
			OJeden oj = new OJeden();
			ODwa od = new ODwa();

			nb = oj;
			Console.WriteLine($"A: {nb.Nastepny(1)}, {nb.ZwiekszODwa(1)}");

			nb = od;
			Console.WriteLine($"B: {nb.Nastepny(1)}, {nb.ZwiekszODwa(1)}");
		}
	}
}
