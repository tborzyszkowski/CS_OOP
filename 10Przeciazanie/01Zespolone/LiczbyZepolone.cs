using System;

namespace _01Zespolone
{
	public struct Zespolona
	{
		public double Re { set; get; }
		public double Im { set; get; }
		public Zespolona(double re, double im)
		{
			this.Re = re;
			this.Im = im;
		}
		public Zespolona(double re)
			: this(re, 0)
		{
		}

		public static Zespolona operator +(Zespolona x) => x;
		
		public static Zespolona operator -(Zespolona x)
		{
			Zespolona y = new Zespolona();
			y.Re = -x.Re;
			y.Im = -x.Im;
			return y;
		}
		public static Zespolona operator ~(Zespolona x)
		{
			Zespolona y = new Zespolona();
			y.Re = x.Re;
			y.Im = -x.Im;
			return y;
		}
		public static double operator !(Zespolona x)
		{
			return Math.Sqrt(x.Re * x.Re + x.Im * x.Im);
		}

		public static Zespolona operator +(Zespolona x, Zespolona y)
		{
			Zespolona z = new Zespolona();
			z.Re = x.Re + y.Re;
			z.Im = x.Im + y.Im;
			return z;
		}

		public static Zespolona operator -(Zespolona x, Zespolona y)
		{
			Zespolona z = new Zespolona();
			z.Re = x.Re - y.Re;
			z.Im = x.Im - y.Im;
			return z;
		}

		public static Zespolona operator *(Zespolona x, Zespolona y)
		{
			Zespolona z = new Zespolona();
			z.Re = x.Re * y.Re - x.Im * y.Im;
			z.Im = x.Im * y.Re + x.Re * y.Im;
			return z;
		}

		public static Zespolona operator /(Zespolona x, Zespolona y)
		{
			Zespolona z = new Zespolona();
			z.Re = (x.Re * y.Re + x.Im * y.Im) / (y.Re * y.Re + y.Im * y.Im);
			z.Im = (x.Im * y.Re - x.Re * y.Im) / (y.Re * y.Re + y.Im * y.Im);
			return z;
		}

		public static bool operator ==(Zespolona x, Zespolona y)
		{
			return x.Re == y.Re && x.Im == y.Im;
		}

		public static bool operator !=(Zespolona x, Zespolona y)
		{
			return !(x == y);
		}

		public override bool Equals(object obj)
		{
			Zespolona y = (Zespolona)obj;
			return this.Re == y.Re && this.Im == y.Im;
		}
		public override int GetHashCode()
		{
			return (int)!this;
		}

		public static explicit operator double(Zespolona x)
		{
			return x.Re;
		}

		public static implicit operator Zespolona(double d) => new Zespolona(d);
		public override string ToString()
		{
			return $"({this.Re}, {this.Im})";
		}
	}
}
