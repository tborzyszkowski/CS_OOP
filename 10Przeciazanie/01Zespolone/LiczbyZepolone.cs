using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Zespolone {
    public struct Zespolona {
        private double re;

        public double Re {
            set { re = value; }
            get { return re; }
        }
        private double im;
        public double Im {
            set { im = value; }
            get { return im; }
        }
        public Zespolona(double re, double im) {
            this.re = re;
            this.im = im;
        }
        public Zespolona(double re)
            : this(re, 0) {
        }

        //definicja domyślnego konstruktora jest niedozwolona
        //public Zepolona()

        public static Zespolona operator +(Zespolona x) {
            return x;
        }
        public static Zespolona operator -(Zespolona x) {
            Zespolona y;
            y.re = -x.re;
            y.im = -x.im;
            return y;
        }
        //operator ~ będzie wyznaczał liczbę sprzężoną
        public static Zespolona operator ~(Zespolona x) {
            Zespolona y;
            y.re = x.re;
            y.im = -x.im;
            return y;
        }
        //operator ! będzie wyznaczał moduł liczby zespolone
        public static double operator !(Zespolona x) {
            return Math.Sqrt(x.re * x.re + x.im * x.im);
        }

        public static Zespolona operator +(Zespolona x, Zespolona y) {
            Zespolona z;
            z.re = x.re + y.re;
            z.im = x.im + y.im;
            return z;
        }

        public static Zespolona operator -(Zespolona x, Zespolona y) {
            Zespolona z;
            z.re = x.re - y.re;
            z.im = x.im - y.im;
            return z;
        }

        public static Zespolona operator *(Zespolona x, Zespolona y) {
            Zespolona z;
            z.re = x.re * y.re - x.im * y.im;
            z.im = x.im * y.re + x.re * y.im;
            return z;
        }

        public static Zespolona operator /(Zespolona x, Zespolona y) {
            Zespolona z;
            z.re = (x.re * y.re + x.im * y.im) / (y.re * y.re + y.im * y.im);
            z.im = (x.im * y.re - x.re * y.im) / (y.re * y.re + y.im * y.im);
            return z;
        }

        public static bool operator ==(Zespolona x, Zespolona y) {
            return x.re == y.re && x.im == y.im;
        }

        public static bool operator !=(Zespolona x, Zespolona y) {
            return !(x == y);
        }

        public override bool Equals(object obj) {
            Zespolona y = (Zespolona)obj;
            return this.re == y.re && this.im == y.im;
        }
        public override int GetHashCode() {
            return (int)!this;
        }

        public static explicit operator double(Zespolona x) {
            return x.Re;
        }

        public static implicit operator Zespolona(double d) {
            Zespolona x = new Zespolona();
            x.re = d;
            return x;
        }

    }
}
