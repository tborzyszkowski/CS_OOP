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
            if ((x != null) && (y != null))
            {
                if (x.Age > y.Age) return 1;
                else if (x.Age < y.Age) return -1;
                else return String.Compare(x.Name, y.Name);
            }
            if ((x is null) && (y != null)) { return -1; }
            if (x != null) { return 1; }

            return 0;
        }
	}
}
