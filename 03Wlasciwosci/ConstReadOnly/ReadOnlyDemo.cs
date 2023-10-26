using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstReadOnly {
	class ReadOnlyDemo
	{
		public readonly int value;

		public ReadOnlyDemo(int value)
		{
			this.value = value;
			//this.value = 7;
		}
		//public void meth() {
		//	this.value = 8;
		//}
	}
}
