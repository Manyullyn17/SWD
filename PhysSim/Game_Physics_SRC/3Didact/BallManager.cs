
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Balls6
{

    // Managen von Lebenszeit, Bewegung, und Reflexionen mehrerer Bälle.
    // Die verwalteten Bälle können auch unterschiedliche Flugeigenschaften 
    // z.B. mit oder ohne Schwerkraft haben
    // BasisKlasse für andere erweiterte BallManager wie z.B.
    // BillardManager, TwoBallCollider, PingPong-Manager
    public class BallManager
    {
        protected ArrayList m_BallList = new ArrayList();

        public BallManager() { }

        public void Info1(Label aInfoField)
        {
            if (m_BallList.Count == 0)
            {
                aInfoField.Text = String.Format("Empty", m_BallList.Count);
                return;
            }
            Ball bl = (Ball)m_BallList[0];
            aInfoField.Text =
            String.Format("V:{0:F1}:{1:F1}", bl.V.GetR(), bl.V.GetPhiGrad());
        }

        public void BallInfo(Label aInfoField, Point aMousePos)
        {
            foreach (Ball bl in m_BallList)
            {
                if (bl.HitRadius(aMousePos))
                {
                    // aInfoField.Text = String.Format("V:{0:F1}  {1:F1}", bl.V.GetR(), bl.V.GetPhiGrad());
                    // aInfoField.Text = String.Format("Pos: {0}", bl.Pos);
                    aInfoField.Text =
                    String.Format("V:{0:F1}:{1:F1} P:{2}", bl.V.GetR(), bl.V.GetPhiGrad(), bl.Pos);
                    return;
                }
            }
            aInfoField.Text = "";
        }

        public void AddBall(Ball aBall)
        {
            m_BallList.Add(aBall);
        }

        public bool DeleteBallAtPos(Point aPos)
        {
            foreach (Ball bl in m_BallList)
            {
                if (bl.HitRadius(aPos))
                {
                    m_BallList.Remove(bl);
                    return true;
                }
            }
            return false;
        }

        // Basisimplemntierung und Schnittstelle zu
        // abgeleiteten BallManagern
        #region Interface for derived Managers
        public virtual void CalcNextPositions()
        {
            for (int i = 0; i < Par.ITER_PER_TICK; i++)
            {
                foreach (Ball bl in m_BallList)
                {
                    if (bl.ReflectInWindow(Ball.WndSize))
                        bl.WasReflected();
                    bl.CalcNextPos();
                }
            }
        }

        public virtual void Paint(Graphics aGr)
        {
            foreach (Ball bl in m_BallList)
            {
                bl.PaintVisible(aGr);
            }
        }

        public virtual void MouseMove(MouseEventArgs e, Graphics aGr)
        {
        }
        #endregion
    }
}
