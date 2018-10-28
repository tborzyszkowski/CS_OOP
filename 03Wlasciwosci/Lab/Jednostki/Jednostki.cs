using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jednostki {
    class Jednostki : IQuantity, ILength {
        public int Sztuka { get; set; }
        public int Kopa {
            get => Sztuka / 60;
            set => Sztuka = 60 * value;
        }
        public int Metr { get; set; }
        public int Milimetr {
            get => Metr * 1000;
            set => Metr = value / 1000;
        }
    }
}
