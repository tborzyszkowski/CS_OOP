using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punkt {
	class Punkt {
		public double X = 0, Y = 0;

		public Punkt(double x, double y) {
			this.X = x;
			this.Y = y;
		}
		public override String ToString() => $"({X}, {Y})";

		public double Odleglosc() => Math.Sqrt(X * X + Y * Y);

		public double OdlegloscDwa(Punkt p) =>
			Math.Sqrt(
				(p.X - this.X) * (p.X - this.X) +
				(p.Y - this.Y) * (p.Y - this.Y)
			);

		public bool IsTiangle(Punkt p1, Punkt p2)
		{
			var thisP1 = this.OdlegloscDwa(p1);
			var thisP2 = this.OdlegloscDwa(p2);
			var p1p2 = p1.OdlegloscDwa(p2);

			return ! (thisP1 + thisP2 <= p1p2) && (thisP1 + p1p2 <= thisP2) && (p1p2 + thisP2 <= thisP1);
		}
	}
}
