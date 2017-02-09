using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Czolg {
    struct Punkt {
        private int x;
        private int y;

        public Punkt(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int PobierzX() {
            return x;
        }
        public int PobierzY() {
            return y;
        }
        #region Zadanie 2
        public void ZmienX(int noweX) {
            x = noweX;
        }
        public void ZmienY(int noweY) {
            y = noweY;
        }
        #endregion

    }
}
