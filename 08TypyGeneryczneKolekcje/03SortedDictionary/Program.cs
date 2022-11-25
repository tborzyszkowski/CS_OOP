using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SortedDictionary
{
	class Program
	{
		static void Main(string[] args)
		{
			SortedDictionary<string, string> openWith =
				new SortedDictionary<string, string>(
					StringComparer.CurrentCultureIgnoreCase)
				{
					{"txt", "notepad.exe"}, 
					{"bmp", "paint.exe"}, 
					{"DIB", "paint.exe"}, 
					{"rtf", "wordpad.exe"}
				};
			try
			{
				openWith.Add("BMP", "paint_new.exe");
			}
			catch (ArgumentException)
			{
				Console.WriteLine("\nBMP is already in the dictionary.");
			}
			Console.WriteLine();
			foreach (var kvp in openWith)
			{
				Console.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");
			}
		}
	}
}
