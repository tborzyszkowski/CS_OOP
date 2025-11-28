using System;

namespace _00OuterAssembly {
	public class ZewnetrznaOuter {
		internal void fInternalProtected() {
			Console.WriteLine("Outside.Zewnetrzna.f()");
			//DrugaOuter dro = new DrugaOuter();
			//dro.g();
		}
		internal void fInternal() { }
		protected void fProtected() { }
	}

	public class DrugaOuter {
		void g() {
			new ZewnetrznaOuter().fInternalProtected();
		}
	}
}
