using System.Drawing;

namespace Balls6
{
    class GravityBall3 : Ball
    {
        public GravityBall3()
          : base()
        {
        }

        public GravityBall3(Point aPos, Color aCol, double aV, double aDirection)
          : base(aPos, aCol, aV, aDirection)
        {
        }

        public override void CalcNextPos()
        {
            // Vn+1 = Vn*KRcalc;   Vn+1 = Vn*(1 - KR*DT);
            m_V = m_V.ScalarMult(Par.KR_CALC);

            // Vy(n+1) = -g*dt;
            m_V.Y = m_V.Y - Par.EARTH_ACCEL;

            // Xn+1 = Vn*dt + Xn;
            m_Pos.AddTo(m_V, Par.DT);
        }
    }
}
