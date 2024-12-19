using System;
using System.Text;


namespace Complex
{
  class Program
  {
    static void Main(string[] args)
    {
      Test2();
    }

    static void Test1()
    {
      Complex a = new Complex(3, 4); // a = 3 + j*4
      Complex b = new Complex(5, -7); // a = 5 - j*7
      Complex c;

      c = Complex.Add(a, b); // c = a + b + Complex(7,8) + a;

      c = a + b + new Complex(7, 8) + a;

      Console.WriteLine("a={0}  b={1}  c={2}", a, b, c);

    }

    static void Test2()
    {
      Complex a = new Complex(3, 10, true); // 3\10° in Plolarkoordinaten
      Complex b = new Complex(2, 20, true); // 2\20° in Plolarkoordinaten

      Complex c = a * b;

      Console.WriteLine("a={0}  b={1}  c={2}", a.Polar(), b.Polar(), c.Polar());
    }
  }
}
