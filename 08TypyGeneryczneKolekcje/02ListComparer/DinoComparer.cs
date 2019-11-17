using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ListComparer
{
	public class DinoComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			if (x == null)
				if (y == null)
					return 0;
				else
					return -1;
			else
			{
				if (y == null)
				{
					return 1;
				}
				else
				{
					var retval = x.Length.CompareTo(y.Length);

					if (retval != 0)
						return retval;
					else
						return x.CompareTo(y);
				}
			}
		}
	}
}
