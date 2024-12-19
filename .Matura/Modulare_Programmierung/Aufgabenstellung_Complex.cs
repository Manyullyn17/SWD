using System;
using System.Text;

namespace Complex
{
  class Aufgabenstellung
  {
    void F1()
    {
      // C# hat eingebaute Arithmetik für int float double

      float a = 0, b = 0, c = 0;

      c = a * (3.5 * b + a) + sin(b*3.14);

      // das hätten wir auch gerne für Complexe zahlen

      Complex a(3,4);  // a = 3 + j*4;
      Complex b(-2,5); // b = -2 + j*5;
      Complex c;

      c = a*(b + Complex(7,8));

      Console.WriteLine(a,b,c);
      
      // c = 3 + j * 4;

    }
  }
}
