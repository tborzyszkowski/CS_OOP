using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstReadOnly {
	class Program {
		static void Main(string[] args) {
			ConstDemo constDemo1 = new ConstDemo();
			ConstDemo constDemo2 = new ConstDemo();

			ReadOnlyDemo readOnlyDemo1 = new ReadOnlyDemo(13);
			ReadOnlyDemo readOnlyDemo2 = new ReadOnlyDemo(30);

			int i = readOnlyDemo1.value;
			//readOnlyDemo1.value = 0;
		}
	}
}
