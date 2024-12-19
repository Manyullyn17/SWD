using System;
using System.Linq;
using System.Text;


namespace Complex
{
  struct Complex
  {
    double _re, _im;

    const double RAD_GRAD = 180.0 / Math.PI;
    const double GRAD_RAD = Math.PI / 180.0;

    public Complex(double aRe, double aIm, bool aIsPolar=false)
    {
      if (aIsPolar)
      {
        double r = aRe; double phi = aIm;
        _re = r * Math.Cos(phi* GRAD_RAD);
        _im = r * Math.Sin(phi* GRAD_RAD);
      }
      else
      {
        _re = aRe; _im = aIm;
      }
    }

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

    public static Complex operator *(Complex aA, Complex aB)
    {
      Complex prod;
      prod._re = aA._re * aB._re - aA._im * aB._im;
      prod._im = aA._im * aB._re + aA._re * aB._im;
      return prod;
    }

    // gibt die Zahl als Text in Polarkoordinaten zurück
    public string Polar()
    {
      double r = Math.Sqrt(_re * _re + _im * _im);
      double phi = RAD_GRAD*Math.Atan2(_im, _re);
      return string.Format("{0}/{1}", r, phi);
    }

    public override string ToString()
    {
      if( _im > 0)
        return string.Format("{0} + j*{1}", _re, _im);
      else
        return string.Format("{0} - j*{1}", _re, -_im);
    }
  }
}
