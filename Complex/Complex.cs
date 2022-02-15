using System;
using System.Text;

namespace Complex
{
    struct Complex
    {
        double _re, _im;

        public Complex(double aRe, double aIm)
        {
            _re = aRe; _im = aIm;
        }

        public override string ToString()
        {
            if (_im >= 0)
                return string.Format("{0} + j*{1}", _re, _im);
            else
                return string.Format("{0} - j*{1}", _re, -_im);
        }
    }
}
