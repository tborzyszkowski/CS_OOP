using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punkt
{
    class Punkt
    {
        public double x = 0, y = 0;
        
        public override String ToString() => $"({x}, {y})";

        public double Odleglosc() => Math.Sqrt(x * x + y * y);

        public double OdlegloscDwa(Punkt p) => 
            Math.Sqrt(
                (p.x - this.x) * (p.x - this.x) + 
                (p.y - this.y) * (p.y - this.y)
            );
    }
}
