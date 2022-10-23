using System.Drawing;

namespace Balls6
{
    class FrictionBall3 : Ball
    {
        public FrictionBall3()
          : base()
        {
        }

        public FrictionBall3(Point aPos, Color aCol, double aV, double aDirection)
          : base(aPos, aCol, aV, aDirection)
        {
        }

        public override void CalcNextPos()
        {
            // Vn+1 = Vn*KRcalc;   Vn+1 = Vn*(1 - KR*DT);
            m_V = m_V.ScalarMult(Par.KR_CALC);
            // Xn+1 = Vn*dt + Xn;
            m_Pos.AddTo(m_V, Par.DT);
        }
    }
}
