using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Person> persons = new List<Person>()
			{
				new Person("Anna", 20),
				new Person("Zuza", 15),
				new Person("Kasia", 15),
				new Person("Gosia", 19),
				new Person("Zuza", 50),
			};

			persons.Sort();

			foreach (var person in persons)
			{
				Console.WriteLine(person);
			}
			Console.WriteLine("------------");
			persons.Sort(new PersonComparer());

			//foreach (var person in persons)
			//{
			//	Console.WriteLine(person);
			//}

			Console.WriteLine(
				String.Join<Person>("\n", persons.ToArray())
				);
		}
	}
}
