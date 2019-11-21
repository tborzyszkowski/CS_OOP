using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
	class PersonComparer : IComparer<Person>
	{
		public int Compare(Person x, Person y)
		{
			if (x.Age > y.Age) return 1;
			else if (x.Age < y.Age) return -1;
			else return x.Name.CompareTo(y.Name);
		}
	}
}
