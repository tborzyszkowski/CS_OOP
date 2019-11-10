using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Protected {
	class Bazowa {
		private int a;
		protected int b;
		public int c;
	}
	class Pochodna : Bazowa {
		public void F(Pochodna p) {
			//int a = p.a; //Błąd, nie mamy dostępu do składowych prywatnych
			//klasy bazowej
			int b = p.b; //OK
			int c = p.c; //OK, składowe publiczne
		}
		public void G(Bazowa p) {
			//int a = p.a; //Błąd, nie mamy dostępu do składowych prywatnych
			//klasy bazowej
			//int b = p.b; //Błąd!!! Nie możemy odwołać się do składowej
			//chronionej przy pomocy zmiennej klasy bazowej
			int c = p.c; //OK, składowe publiczne
		}
	}
	class Program {
		static void Main(string[] args) {
		}
	}
}
