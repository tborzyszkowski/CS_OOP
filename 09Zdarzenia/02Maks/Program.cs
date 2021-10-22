using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Maks
{
	public delegate int Comparison<in T>(T left, T right);

	class ListMax<T> where T : IComparable
	{
		private List<T> list;
		private Comparison<T> comparator;

		public ListMax()
		{
			list = new List<T>();
			comparator += (a, b) => a.CompareTo(b);
		}

		public ListMax(List<T> list)
		{
			this.list = list;
			comparator += (a, b) => a.CompareTo(b);
		}

		public ListMax(Comparison<T> comp)
		{
			list = new List<T>();
			comparator += comp;
		}

		public ListMax(List<T> list, Comparison<T> comp) : this(list)
		{
			//this.list = list;
			comparator += comp;
		}

		public ListMax<T> Add(T item)
		{
			list.Add(item);
			return this;
		}

		public T GetMax()
		{
			T max = default(T);
			if (list.Count() > 0)
			{
				max = list[0];
				foreach (T item in list)
				{
					if (comparator(max, item) < 0)
						max = item;
				}
			}
			return max;
		}

	}
	class Program
	{
		static void Main(string[] args)
		{
			ListMax<int> intList = (new ListMax<int>()).Add(1).Add(6).Add(3);
			Console.WriteLine($"Max = {intList.GetMax()}");
			intList = (new ListMax<int>((a, b) => b.CompareTo(a))).Add(1).Add(6).Add(3);
			Console.WriteLine($"Max = {intList.GetMax()}");
			ListMax<string> strList = (new ListMax<string>()).Add("Ala").Add("Zuza").Add("Hermenegilda");
			Console.WriteLine($"Max = {strList.GetMax()}");
			strList = (new ListMax<string>((a, b) => a.Length.CompareTo(b.Length))).Add("Ala").Add("Zuza").Add("Hermenegilda");
			Console.WriteLine($"Max = {strList.GetMax()}");
		}
	}
}
