using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04WczesnaImplementacja
{
	interface Interface1
	{
		void F();
	}
	class A
	{
		public void F()
		{
			Console.WriteLine("f() z A");
		}
	}
	class B : A, Interface1
	{
	}

	class Program
	{
		static void Main(string[] args)
		{
			B b = new B();
			b.F();
			((A)b).F();
			((Interface1)b).F();
			A a = new A();
			Interface1 ii = a as Interface1;
			if (ii != null)
				Console.WriteLine("Interface1 tu byłem");
			ii?.F();
		}
	}
}
