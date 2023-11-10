using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04ZgodnoscTypow {
	class A {
		public int X { get; set; }
		
		//public A(int a) {
		//	this.X = 1;
		//}
		

	}
	class B : A {
		public int X { get; set; }
		public B() {
			this.X = 2;
		}
		
		public void setBaseX(int value) {
			base.X = value;
		}
		public override string ToString() {
			return $"B: x = {X}, base.X= {base.X}";
		}
	}
	class Program {
		static void Main(string[] args) {
			A pa = new A();
			B pb = new B();

			pa.X = 5;
			pb.X = 15;
			pb.setBaseX(16);

			Console.WriteLine($"A: pa.x = {pa.X}");
			Console.WriteLine(pb);
			Console.WriteLine(pa.GetType());
			Console.WriteLine(pb.GetType());
			Console.WriteLine();
			pa = pb;
			//pb = pa;

			Console.WriteLine($"A: pa.x = {pa.X}");
			Console.WriteLine(pb);
			Console.WriteLine(pa.GetType());
			Console.WriteLine(pb.GetType());

			//B pb2 = (B)pa;
			B pb2 = pa as B;
			Console.WriteLine(pb2);
			Console.WriteLine(pb2?.GetType());

			A pa2 = (A)(new B());
			Console.WriteLine(pa2.GetType());
		}
	}
}
