using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Zoo {
	class Owca : Zwierze {
		public override void WydajGlos() {
			Console.WriteLine("Beee...");
		}
		public override string NazwaLacinska
		{
			get { return "Ovis aries"; }
		}
		public override string ToString() {
			return "owca";
		}
	}
}
