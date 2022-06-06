using System;
// using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MV;

namespace Balls6
{
  // Ball mit Reibung
  class FrictionBall2 : Ball
  {
    public FrictionBall2(): base() {}

    public FrictionBall2(Point aPos, Color aCol, double aV, double aDirection)
      : base(aPos, aCol, aV, aDirection)
		{
    }

    public override void CalcNextPos()
    {
      // Vn+1 = Vn*KRcalc;   Vn+1 = Vn*(1 - KR*DT);
      m_V = m_V.ScalarMult(Par.KR_CALC);
      //Xn+1 = Vn*dt + Xn;
      m_Pos.AddTo(m_V, Par.DT);
    }
  }
}
