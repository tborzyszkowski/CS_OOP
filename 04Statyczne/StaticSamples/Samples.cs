using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSamples {
	public class Samples {
		static int pole;

		static Samples() {
			pole = 10;
		}

		//static Samples(int a) {
		//	pole = 11;
		//}
	}
}
