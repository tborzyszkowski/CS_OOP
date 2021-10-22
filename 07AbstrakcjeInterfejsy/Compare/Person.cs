using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
	public class Person : IComparable<Person>
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public override string ToString()
		{
			return "Person { Name = " + Name + ", Age = " + Age + " }";
		}

		public int CompareTo(Person other) {
			if (this.Name.CompareTo(other.Name) == 0)
			{
				if (this.Age > other.Age) return 1;
				else if (this.Age < other.Age) return -1;
				else return 0;
			}
			else return this.Name.CompareTo(other.Name);
		}
	}
}
