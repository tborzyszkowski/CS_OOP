using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04ZgodnoscTypow {
	class A {
		public int x;
		public void setA(int x) {
			this.x = x;
		}
	}
	class B : A {
		public int x;
		public void setB(int a, int b) {
			this.x = a;
			base.x = b;
		}
		
		public override string ToString() {
			return $"B: x = {x}, base.x = {base.x}";
		}
	}
	class Program {
		static void Main(string[] args) {
			A pa = new A();
			B pb = new B();

			pa.setA(5);
			pb.setB(15, 16);

			Console.WriteLine($"A: pa.x = {pa.x}");
			Console.WriteLine(pb);
			Console.WriteLine(pa.GetType());
			Console.WriteLine(pb.GetType());
			Console.WriteLine();
			pa = pb;
			//pb = pa;

			Console.WriteLine($"A: pa.x = {pa.x}");
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
