using System;

namespace _03GenericDelegates
{
	class GenDelegates
	{
		public Action<int> IterAction;
		public Func<int, bool> Relation;
		public Predicate<int> Proprety;

		public void IterOne(int n)
		{
			for (var i = 0; i < n; i++) Console.WriteLine(i);
		}
		public void IterTwo(int n)
		{
			for (var i = 0; i < n; i++) Console.WriteLine(2 * i);
		}
		public bool RelSample1(int x)
		{
			return x < 7;
		}
		public bool PropEven(int n)
		{
			return n % 2 == 0;
		}
	}
	class Test
	{
		static bool AppFun(Func<int, bool> fn, int val)
		{
			return fn(val);
		}

		static void Main(string[] args)
		{
			GenDelegates gd = new GenDelegates();
			gd.IterAction += gd.IterOne;

			gd.IterAction(6);
			//gd.IterAction -= gd.IterOne;
			gd.IterAction += gd.IterTwo;
			gd.IterAction(6);

			gd.Relation += gd.RelSample1;
			Console.WriteLine(gd.Relation(1));
			gd.Relation -= gd.RelSample1;
			gd.Relation += (x) => x < 3;
			Console.WriteLine(gd.Relation(1));
			gd.Relation += gd.PropEven;
			Console.WriteLine(gd.Relation(1));

			gd.Proprety += gd.PropEven;
			Console.WriteLine(gd.Proprety(3));
			gd.Proprety -= gd.PropEven;
			gd.Proprety += x => x % 2 == 1;
			Console.WriteLine(gd.Proprety(3));

			Console.WriteLine(AppFun(gd.Relation, 6));
			// AppFun(gd.Proprety, 6);

		}
	}
}
