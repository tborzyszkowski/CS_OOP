using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMethodCS {
	class A {
		public void F() {
			Console.WriteLine("A.F()");
		}
		public virtual void G() {
			Console.WriteLine("A.G()");
		}
	}
	class B : A {
		public new void F() {
			Console.WriteLine("B.F()");
		}
		public override void G() {
			Console.WriteLine("B.G()");
		}
	}
	class Program {
		static void Main(string[] args) {
			A a = new A();
			a.F();
			a.G();

			a = new B();
			a.F();
			a.G();

			B b = new B();
			b.F();
			b.G();
		}
	}
}
