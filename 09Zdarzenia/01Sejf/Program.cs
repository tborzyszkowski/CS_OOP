using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    public class AlarmEventArgs : EventArgs {
        private DateTime kiedy = DateTime.Now;
        public DateTime Kiedy {
            get { return kiedy; }
        }
    }

    public delegate void AlarmEventHandler(object sender, AlarmEventArgs args);

    class Sejf {
        private string czyj;
        public string Czyj {
            get { return czyj; }
        }
        private int pin;
        public event AlarmEventHandler Alarm;
        public Sejf(string czyj, int pin) {
            this.czyj = czyj;
            this.pin = pin;
        }
        public void OtworzSejf(int pin) {
            if(this.pin != pin) {
                Console.WriteLine("Zły pin. Włączamy alarm.");
                if(Alarm != null)
                    Alarm(this, new AlarmEventArgs());
                return;
            }
            Console.WriteLine("Uzyskałeś dostęp do sejfu");
        }
    }
    class Straznik {
        private string imie, nazwisko;
        public Straznik(string imie, string nazwisko) {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
        public void GonZlodzieja(object sender, AlarmEventArgs e) {
            Sejf s = (Sejf)sender;
            Console.WriteLine(
             $"Strażnik: {imie} {nazwisko}: sejfu pana(i) {s.Czyj}. Alarm: {e.Kiedy}.");
        }
    }

    static class Syrena {
        public static void Wyj(object sender, AlarmEventArgs e) {
            for(int i = 0; i < 1000; i++) {
                Console.Beep(1000 + 10 * i, 10);
            }
            Console.WriteLine("BEEP \t BEEP \t BEEP");
        }
    }

    class Program {
        static void Main(string[] args) {
            Sejf sejf1 = new Sejf("Bill G.", 1234);
            Sejf sejf2 = new Sejf("Jan K.", 4321);
            Straznik s1 = new Straznik("Chuck", "Norris");
            Straznik s2 = new Straznik("John", "Rambo");
            sejf1.Alarm += new AlarmEventHandler(Syrena.Wyj);
            sejf1.Alarm += new AlarmEventHandler(s1.GonZlodzieja);
            sejf2.Alarm += new AlarmEventHandler(s1.GonZlodzieja);
            sejf2.Alarm += new AlarmEventHandler(s2.GonZlodzieja);
            sejf1.OtworzSejf(5678);
            Console.ReadKey(true);
            sejf2.OtworzSejf(8765);
            Console.ReadKey(true);

            sejf2.Alarm -= new AlarmEventHandler(s1.GonZlodzieja);
            sejf2.OtworzSejf(8765);
            Console.ReadKey(true);
        }
    }
}
