
using System;
using System.Text;
using MV;

namespace VectRot
{
  


  class VectRotTest1
  {
    static void Main(string[] args)
    {
      VectRotTest1 t1 = new VectRotTest1();
      t1.Test1();
    }

    void Test1()
    {
      Vect2D r1 = Vect2D.ini; // der gibt die Grad der Drehung vor
      Vect2D v1 = Vect2D.ini; // der wird gedreht

      r1.SetFrom_R_Phi(1, 45); // um 45° vorwärts drehen

      v1.SetXY(10, 0);

      Pr1("Before Rot1:", v1, true);

      v1 = v1.CoMult(r1); // v1 um r1 rotieren

      Pr1("After Rot1:", v1, true);

      r1.SetFrom_R_Phi(1, -45);
      v1 = v1.CoMult(r1);

      Pr1("After Rot2:", v1, true);
    }


    void Pr1(string aTxt, Vect2D aV, bool aNl)
    {
      Console.Write("{0} ", aTxt);
      aV.PrintRPhi();
      if (aNl) Console.WriteLine();
    }
    
    void Pr2(string aTxt, Vect2D aV, bool aNl)
    {
      Console.Write("{0} ", aTxt);
      aV.PrintXY();
      if (aNl) Console.WriteLine();
    }

    void Pr3(string aTxt, Line2D aL, bool aNl)
    {
      Console.WriteLine("{0} {1}", aTxt, aL);
      if (aNl) Console.WriteLine();
    }
  }
}
