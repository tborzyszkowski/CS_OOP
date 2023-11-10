using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00OuterAssembly {
	public class ZewnetrznaOuter {
		internal protected void fInternalProtected() {
			Console.WriteLine("Outside.Zewnetrzna.f()");
			//DrugaOuter dro = new DrugaOuter();
			//dro.g();
		}
		internal protected void fInternal() { }
		protected void fProtected() { }
	}

	public class DrugaOuter {
		void g() {
			new ZewnetrznaOuter().fInternalProtected();
		}
	}
}
