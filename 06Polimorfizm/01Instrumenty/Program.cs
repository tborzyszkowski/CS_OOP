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
            Instrument instrument = new Instrument();
			Console.WriteLine("A - trąba");
			Console.WriteLine("B - bęben");
			char c = Console.ReadKey().KeyChar;
			
			switch (c)
			{
				case 'a':
					instrument = new Traba();
					break;
				case 'b':
					instrument = new Beben();
					break;
			}

			instrument.Graj1();      //zawsze Cisza
			instrument.Graj2();      // nie wiadomo, "użytkownik wybiera"
			Console.WriteLine($"instr.GetType(): {instrument.GetType()}");
			Console.WriteLine($"((Instrument)instr).GetType(): {((Instrument)instrument).GetType()}");
			//((Traba)instr).Dmuchaj();
			(instrument as Traba)?.Dmuchaj();
			Traba tr = new Traba();
			tr.Graj1();
			instrument = new Traba();
            //((Instrument)instrument).Dmuchaj();

            Console.WriteLine(tr.Equals(instrument));
			Console.WriteLine(tr == instrument);
			Console.WriteLine(tr.GetHashCode());
			Console.WriteLine(instrument.GetHashCode());
		}
	}
}
