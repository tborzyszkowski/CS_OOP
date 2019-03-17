using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Czolg {
    class Dzialo {
        private double kaliber;
        public Dzialo(double kaliber) {
            this.kaliber = kaliber;
        }

        public double GetKaliber() {
            return kaliber;
        }
        #region Zadanie 2
        public void SetKaliber(double nowyKaliber) {
            kaliber = nowyKaliber;
        }

        public Dzialo(Dzialo prototyp) {
            kaliber = prototyp.kaliber;
        }
        #endregion
    }
}
