using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02NewVirtual {
	class A {
		public virtual void F() {
			Console.WriteLine("A");
		}
	}
	class B : A {
		public override void F() {
			Console.WriteLine("B");
		}
	}
	class C : B {
		public new virtual void F() {
			Console.WriteLine("C");
		}
	}
	class D : C {
		public override void F() {
			Console.WriteLine("D");
		}
	}
	class Przyklad {
		static void Main(string[] args) {
			A a1 = new A();
			a1.F();
			A a2 = new B();
			a2.F();
			A a3 = new C();
			a3.F();
			A a4 = new D();
			a4.F();
			C c1 = new D();
			c1.F();
		}
	}
}
