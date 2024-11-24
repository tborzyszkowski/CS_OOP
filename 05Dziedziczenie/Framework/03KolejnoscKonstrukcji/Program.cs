using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03KolejnoscKonstrukcji {
	class AK {
		public AK(int i) {
			Console.WriteLine($"Konstruktor z A: {i}");
		}
		public AK()// : this(7)
        {
			Console.WriteLine("Konstruktor z A()");
		}
	}
	class BK : AK {
		public BK(int i) : base(i + 1) {
			Console.WriteLine($"Konstruktor z B: {i}");
		}
		public BK() : this(5)//: base()
		{
			Console.WriteLine("Konstruktor z B()");
		}
	}
	class CK : BK {
		public CK(int i) : base() //: base(2 * i)//: base()
		{
			Console.WriteLine($"Konstruktor z C: {i}");
		}
	}
	class KonstrDemo {
		static void Main(string[] args) {
			new CK(5);
		}
	}
}
