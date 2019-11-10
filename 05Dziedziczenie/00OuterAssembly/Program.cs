using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00OuterAssembly {
	public class ZewnetrznaOuter {
		internal protected void f() {
			Console.WriteLine("Outside.Zewnetrzna.f()");
		}
	}

	public class DrugaOuter {
		void g() {
			new ZewnetrznaOuter().f();
		}
	}
}
