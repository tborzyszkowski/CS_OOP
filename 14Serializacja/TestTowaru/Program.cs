using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.IO;
using TowarXml;

namespace TestTowaru
{
    class Program
    {
        static void Main(string[] args)
        {
            Towar[] oferta = 
            {
                new Towar(){Nazwa="Jabłka", CenaDetaliczna=2.5m, CenaHurtowa=1.2m, IdTowaru=1},
                new Towar(){Nazwa="Śliwki", CenaDetaliczna=3.2m, CenaHurtowa=1.5m, IdTowaru=3},
                new Towar(){Nazwa="Truskawki", CenaDetaliczna=3.8m, CenaHurtowa=1.6m, IdTowaru=4},
            };
            XmlSerializer serializer = new XmlSerializer(typeof(Towar[]));
            FileStream fs = null;
            try
            {
                fs = new FileStream("Oferta.xml", FileMode.Create);
                serializer.Serialize(fs, oferta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Uwaga wyjątek: {0}!!!", ex.Message);
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
                Console.WriteLine("Uwaga wyjątek: {0}!!!", ex.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            foreach (Towar t in kopiaOferty)
            {
                Console.Write("Towar {0}, cena detaliczna - {1}, ", t.Nazwa, t.CenaDetaliczna);
                Console.WriteLine("cena hurtowa - {0}, id towaru - {1}", t.CenaHurtowa, t.IdTowaru);
            }

            Console.WriteLine("--Koniec--");
            Console.ReadKey();

        }
    }
}
