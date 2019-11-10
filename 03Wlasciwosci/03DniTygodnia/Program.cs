using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03DniTygodnia {
	class DayCollection {
		string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };

		private int GetDay(string testDay)
		{

			for (int j = 0; j < days.Length; j++)
			{
				if (days[j] == testDay)
				{
					return j;
				}
			}
			return -1;
		}

		public int this[string day] {
			get => GetDay(day);
		}
	}

	class Program {
		static void Main(string[] args)
		{
			DayCollection week = new DayCollection();
			System.Console.WriteLine(week["Fri"]);
			System.Console.WriteLine(week["Made-up Day"]);
		}
	}
}
