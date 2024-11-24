using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Protected {
	class Bazowa {
		private int a;
		//protected int b;
        protected int b;
		public int c;
	}
	class Pochodna : Bazowa {
		public void F(Pochodna p) {
			//int a = p.a;
			int b = p.b;
			int c = p.c;
		}
		public void G(Bazowa p) {
			//int a = p.a;
			//int b = p.b;
			int c = p.c;
		}
	}
	class Program {
		static void Main(string[] args) {
		}
	}
}
