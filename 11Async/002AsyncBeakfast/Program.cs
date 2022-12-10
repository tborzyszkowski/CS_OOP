using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _002AsyncBeakfast {
	internal class Bacon { }
	internal class Coffee { }
	internal class Egg { }
	internal class Juice { }
	internal class Toast { }

	class Program {
		static async Task Main(string[] args) {
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			#region NotInParallel001
			//Coffee cup = PourCoffee();
			//Console.WriteLine("coffee is ready");

			//Egg eggs = await FryEggsAsync(2);
			//Console.WriteLine("eggs are ready");

			//Bacon bacon = await FryBaconAsync(3);
			//Console.WriteLine("bacon is ready");

			//Toast toast = await ToastBreadAsync(2);
			//ApplyButter(toast);
			//ApplyJam(toast);
			//Console.WriteLine("toast is ready");

			//Juice oj = PourOJ();
			//Console.WriteLine("oj is ready");
			//Console.WriteLine("Breakfast is ready!");
			#endregion

			#region SomeParallelTasks002
			//Coffee cup = PourCoffee();
			//Console.WriteLine("Coffee is ready");

			//Task<Egg> eggsTask = FryEggsAsync(2);
			//Task<Bacon> baconTask = FryBaconAsync(3);
			//Task<Toast> toastTask = ToastBreadAsync(2);

			//Toast toast = await toastTask;
			//ApplyButter(toast);
			//ApplyJam(toast);
			//Console.WriteLine("Toast is ready");
			//Juice oj = PourOJ();
			//Console.WriteLine("Oj is ready");

			//Egg eggs = await eggsTask;
			//Console.WriteLine("Eggs are ready");
			//Bacon bacon = await baconTask;
			//Console.WriteLine("Bacon is ready");

			//Console.WriteLine("Breakfast is ready!");
			#endregion

			#region ParallelInAnyOrder
			//Coffee cup = PourCoffee();
			//Console.WriteLine("coffee is ready");

			//var eggsTask = FryEggsAsync(2);
			//var baconTask = FryBaconAsync(3);
			//var toastTask = MakeToastWithButterAndJamAsync(2);

			//var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
			//while (breakfastTasks.Count > 0)
			//{
			//	Task finishedTask = await Task.WhenAny(breakfastTasks);
			//	if (finishedTask == eggsTask)
			//	{
			//		Console.WriteLine("eggs are ready");
			//	}
			//	else if (finishedTask == baconTask)
			//	{
			//		Console.WriteLine("bacon is ready");
			//	}
			//	else if (finishedTask == toastTask)
			//	{
			//		Console.WriteLine("toast is ready");
			//	}
			//	breakfastTasks.Remove(finishedTask);
			//}

			//Juice oj = PourOJ();
			//Console.WriteLine("oj is ready");
			//Console.WriteLine("Breakfast is ready!");
			#endregion

			stopWatch.Stop();
			TimeSpan ts = stopWatch.Elapsed;
			string elapsedTime =
				String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
					ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
			Console.WriteLine("RunTime: " + elapsedTime);
		}

		private static Juice PourOJ() {
			Console.WriteLine("Pouring orange juice");
			return new Juice();
		}

		private static void ApplyJam(Toast toast) =>
			Console.WriteLine("Putting jam on the toast");

		private static void ApplyButter(Toast toast) =>
			Console.WriteLine("Putting butter on the toast");
		static async Task<Toast> MakeToastWithButterAndJamAsync(int number) {
			var toast = await ToastBreadAsync(number);
			ApplyButter(toast);
			ApplyJam(toast);

			return toast;
		}
		private static async Task<Toast> ToastBreadAsync(int slices) {
			for (int slice = 0; slice < slices; slice++)
			{
				Console.WriteLine("Putting a slice of bread in the toaster");
			}
			Console.WriteLine("Start toasting...");
			await Task.Delay(300);
			Console.WriteLine("Remove toast from toaster");

			return new Toast();
		}

		private static async Task<Bacon> FryBaconAsync(int slices) {
			Console.WriteLine($"putting {slices} slices of bacon in the pan");
			Console.WriteLine("cooking first side of bacon...");
			await Task.Delay(300);
			for (int slice = 0; slice < slices; slice++)
			{
				Console.WriteLine("flipping a slice of bacon");
			}
			Console.WriteLine("cooking the second side of bacon...");
			await Task.Delay(300);
			Console.WriteLine("Put bacon on plate");

			return new Bacon();
		}

		private static async Task<Egg> FryEggsAsync(int howMany) {
			Console.WriteLine("Warming the egg pan...");
			await Task.Delay(300);
			Console.WriteLine($"cracking {howMany} eggs");
			Console.WriteLine("cooking the eggs ...");
			await Task.Delay(300);
			Console.WriteLine("Put eggs on plate");

			return new Egg();
		}

		private static Coffee PourCoffee() {
			Console.WriteLine("Pouring coffee");
			return new Coffee();
		}
	}
}
