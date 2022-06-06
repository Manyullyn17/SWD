
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MV;

namespace Balls6
{
  // Ball mit Reibung ohne Gravitation
  public class FrictionBall : Ball
  {
    public FrictionBall() : base() { }

    public FrictionBall(Point aPos, Color aCol, double aV, double aDirection)
      : base(aPos, aCol, aV, aDirection)
    {
    }

    public override void CalcNextPos()
    {
      // Vn+1 = Vn*KRcalc;   Vn+1 = Vn*(1 - KR*DT);
      m_V = m_V.ScalarMult(Par.KR_CALC);
      // Xn+1 = Xn + Vn*dt;
      m_Pos.AddTo(m_V, Par.DT);
    }
  }
}











