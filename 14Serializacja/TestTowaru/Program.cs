using System;
using System.Xml.Serialization;
using System.IO;
using TowarXml;

namespace TestTowaru
{
	class Program
	{
		static void Main(string[] args) {
			Towar[] oferta =
			{
				new Towar()
				{
					Nazwa="Jabłka", CenaDetaliczna=2.5m, CenaHurtowa=1.2m, IdTowaru=1
				},
				new Towar()
				{
					Nazwa="Śliwki", CenaDetaliczna=3.2m, CenaHurtowa=1.5m, IdTowaru=3
				},
				new Towar()
				{
					Nazwa="Truskawki", CenaDetaliczna=3.8m, CenaHurtowa=1.6m, IdTowaru=4
				},
			};
			PrintTableOfTowar(oferta);

			XmlSerializer serializer = new XmlSerializer(typeof(Towar[]));
			FileStream fs = null;
			try
			{
				fs = new FileStream("Oferta.xml", FileMode.Create);
				serializer.Serialize(fs, oferta);
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

			Towar[] kopiaOferty = null;
			try
			{
				fs = new FileStream("Oferta.xml", FileMode.Open);
				kopiaOferty = (Towar[])serializer.Deserialize(fs);
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
			foreach (Towar t in kopiaOferty)
			{
				Console.Write($"Towar:{t.Nazwa}\t cena detaliczna: {t.CenaDetaliczna}\t ");
				Console.WriteLine($"cena hurtowa: {t.CenaHurtowa}\t id towaru: {t.IdTowaru}");
			}

			Console.WriteLine("--Koniec--");
			Console.ReadKey();

		}

		private static void PrintTableOfTowar(Towar[] oferta) {
			foreach (Towar t in oferta)
			{
				Console.Write($"Towar:{t.Nazwa}\t cena detaliczna: {t.CenaDetaliczna}\t ");
				Console.WriteLine($"cena hurtowa: {t.CenaHurtowa}\t id towaru: {t.IdTowaru}");
			}
		}
	}
}
