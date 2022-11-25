using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Osoby;

namespace TestOsoby
{
	class Program
	{
		static void Main(string[] args)
		{
			Osoba[] osoby =
			{
				new Osoba(1912,"password")
				{
					Imie="Alan", Nazwisko="Turing"
				},
				new Osoba(1903,"password")
				{
					Imie="John", Nazwisko="Neumann"
				},
				new Osoba(1923,"password")
				{
					Imie="Edgar", Nazwisko="Codd"
				}
			};
			BinaryFormatter formater = new BinaryFormatter();
			FileStream fs = null;
			try
			{
				fs = new FileStream("osoby.dat", FileMode.Create);
				formater.Serialize(fs, osoby);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Uwaga wyjątek: {ex.Message}!!!");
			}
			finally
			{
				if (fs != null)
					fs.Close();
			}

			Osoba[] osoby2 = null;
			using (fs = new FileStream("osoby.dat", FileMode.Open))
			{
				osoby2 = (Osoba[])formater.Deserialize(fs);
			}

			foreach (Osoba o in osoby2)
			{
				Console.WriteLine($"Imię: {o.Imie}, nazwisko: {o.Nazwisko}, ile by miał lat: {o.Wiek}");
				Console.WriteLine($"\thasło password: {o.SprawdzHaslo("password")}");
				Console.WriteLine($"\thasło {o.Imie}{o.Nazwisko}: {o.SprawdzHaslo(o.Imie + o.Nazwisko)}");
			}

			Console.WriteLine("--Koniec--");
			Console.ReadKey();
		}
	}
}
