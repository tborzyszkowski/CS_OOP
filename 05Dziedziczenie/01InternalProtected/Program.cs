using System;
using _00OuterAssembly;
using Outside;

namespace _01InternalProtected {
	//class Wewnetrzna {
	//	internal void g() {
	//		Zewnetrzna z = new Zewnetrzna();
	//		z.fff();
	//		Console.WriteLine("InternalProtected.Wewnetrzna.g()");
	//	}
	//}
	class Wewnetrzna : ZewnetrznaOuter {
		internal void g() {
			fInternalProtected();
			//fInternal();
			fProtected();
			Console.WriteLine("InternalProtected.Wewnetrzna.g()");
		}
	}
	class Program {
		static void Main(string[] args) {
			Wewnetrzna w = new Wewnetrzna();
			w.g();
		}
	}

}
