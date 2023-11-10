using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSamples {
	public class Samples {
		static int pole = 5;

		//static Samples() {
		//	pole = 10;
		//}

		static Samples() {
			pole += 11;
		}
	}
}
