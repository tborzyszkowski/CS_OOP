using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Zoo {
	class Zwierze {
		public virtual void WydajGlos() {
			Console.WriteLine("Zwierze wydają rózne dźwięki...");
		}
		public virtual string NazwaLacinska
		{
			get { return "Animalia"; }
		}
		public override string ToString() {
			return "zwierze";
		}
	}
}
