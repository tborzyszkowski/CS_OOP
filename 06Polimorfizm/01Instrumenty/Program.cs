using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Instrumenty
{
	class Program
	{
		static void Main(string[] args)
		{
			Instrument instr = new Instrument();
			Console.WriteLine("A - trąba");
			Console.WriteLine("B - bęben");
			char c = Console.ReadKey().KeyChar;
			//instr.Graj2();
			// ((Traba)instr).Dmuchaj();
			switch (c)
			{
				case 'a':
					instr = new Traba();
					break;
				case 'b':
					instr = new Beben();
					break;
			}

			instr.Graj1();      //zawsze Cisza
			instr.Graj2();      // nie wiadomo, "użytkownik wybiera"
			Console.WriteLine($"instr.GetType(): {instr.GetType()}");
			Console.WriteLine($"((Instrument)instr).GetType(): {((Instrument)instr).GetType()}");
			//((Traba)instr).Dmuchaj();
			(instr as Traba)?.Dmuchaj();
			Traba tr = new Traba();
			tr.Graj1();
			instr = new Traba();
			Console.WriteLine(tr.Equals(instr));
			Console.WriteLine(tr == instr);
			Console.WriteLine(tr.GetHashCode());
			Console.WriteLine(instr.GetHashCode());
		}
	}
}
