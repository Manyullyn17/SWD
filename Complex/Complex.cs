using System;
using System.Text;

namespace Complex
{
    struct Complex
    {
        double _re, _im;
        const double RAD_GRAD = 180.0 / Math.PI;
        const double GRAD_RAD = 1.0 / RAD_GRAD;

        public Complex(double aRe, double aIm)
        {
            _re = aRe; _im = aIm;
        }

        // statischer Konstruktor für bessere Performance
        public static Complex Create(double aRe, double aIm, bool aIsPolar=false)
        {
            Complex ret;
            if (!aIsPolar)
            {
                ret._re = aRe; ret._im = aIm;
            } 
            else
            {
                double r = aRe; double phi = aIm;
                ret._re = r * Math.Cos(phi * GRAD_RAD);
                ret._im = r * Math.Sin(phi * GRAD_RAD);
            }
            return ret;
        }

        // Add als Member-Funktion
        public Complex Add(Complex aB)
        {
            Complex sum;
            sum._re = this._re + aB._re;
            sum._im = this._im + aB._im;
            return sum;
        }

        // Add als statische Funktion
        public static Complex Add(Complex aA, Complex aB)
        {
            Complex sum;
            sum._re = aA._re + aB._re;
            sum._im = aA._im + aB._im;
            return sum;
        }

        public static Complex operator+(Complex aA, Complex aB)
        {
            Complex sum;
            sum._re = aA._re + aB._re;
            sum._im = aA._im + aB._im;
            return sum;
        }

        public static Complex operator*(Complex aA, Complex aB)
        {
            Complex sum;
            sum._re = aA._re * aB._re - aA._im * aB._im;
            sum._im = aA._im * aB._re + aA._re * aB._im;
            return sum;
        }

        public string AsPolar()
        {
            double r = Math.Sqrt(_re * _re + _im * _im);
            double phi = Math.Atan2(_im, _re) * RAD_GRAD;
            return string.Format("{0}\\{1}°", r, phi);
        }

        public override string ToString()
        {
            if( _im >= 0 )
                return string.Format("{0:F2} + j*{1:F2}", _re, _im);
            else
                return string.Format("{0:F2} - j*{1:F2}", _re, -_im);
    }
    }
}
