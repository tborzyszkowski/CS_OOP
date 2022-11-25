using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Czolg
{
	class Program
	{
		static void Main(string[] args)
		{
			Punkt p1 = new Punkt(); //wszystko OK - struktura
									//Dzialo dz = new Dzialo(); //Blad - dla klas nie jest definiowany konstruktor domyslny gdy istnieje inny konstruktor
			Dzialo dz1 = new Dzialo(78);

			Czolg czolg1 = new Czolg(100, "Czolg 1", dz1, p1);
			Czolg czolg2 = new Czolg();
			Czolg czolg3 = new Czolg(103, "Czolg 3", 83.5, 10, 34);
			Console.WriteLine(czolg1);
			Console.WriteLine(czolg2);
			Console.WriteLine(czolg3);

			#region Zadanie 2
			Console.WriteLine("\nKopiowanie płytkie.");
			Czolg oryginal1 = new Czolg(200, "Oryginal 1", 100, 10, 10);
			Czolg klon1 = oryginal1.Klonuj();
			Console.WriteLine("Oryginał: {0}", oryginal1);
			Console.WriteLine("Klon:     {0}", klon1);
			Console.WriteLine("Zmieniamy klona: ");
			klon1.SetKaliber(300);
			klon1.SetNazwa("Klon 1: ");
			klon1.SetPozycja(55, 55);
			Console.WriteLine("Oryginał: {0}", oryginal1);
			Console.WriteLine("Klon:     {0}", klon1);

			Console.WriteLine("\nKopiowanie głębokie.");
			Czolg oryginal2 = new Czolg(200, "Oryginal 2", 100, 10, 10);
			Czolg klon2 = new Czolg(oryginal2);
			Console.WriteLine("Oryginał: {0}", oryginal2);
			Console.WriteLine("Klon:     {0}", klon2);
			Console.WriteLine("Zmieniamy klona: ");
			klon2.SetKaliber(300);
			klon2.SetNazwa("Klon 2");
			klon2.SetPozycja(55, 55);
			Console.WriteLine("Oryginał: {0}", oryginal2);
			Console.WriteLine("Klon:     {0}", klon2);

			#endregion
		 }
	}
}
