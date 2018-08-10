using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                new Osoba(1912,"password"){Imie="Alan", Nazwisko="Turing"},
                new Osoba(1903,"password"){Imie="John", Nazwisko="Neumann"},
                new Osoba(1923,"password"){Imie="Edgar", Nazwisko="Codd"}     
               
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
                Console.WriteLine("Uwaga wyjątek: {0}!!!", ex.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            Osoba[] osoby2 = null;
            try
            {
                fs = new FileStream("osoby.dat", FileMode.Open);
                osoby2 = (Osoba[]) formater.Deserialize(fs);
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
            foreach (Osoba o in osoby2)
            {
                Console.WriteLine("Imię: {0}, nazwisko: {1}, ile by miał lat: {2}",
                    o.Imie,o.Nazwisko,o.Wiek);
                Console.WriteLine("\thasło password: {0}", o.SprawdzHaslo("password"));
                Console.WriteLine("\thasło {1}{2}: {0}",
                    o.SprawdzHaslo(o.Imie+o.Nazwisko),o.Imie,o.Nazwisko);
            }

            Console.WriteLine("--Koniec--");
            Console.ReadKey();
        }
    }
}
