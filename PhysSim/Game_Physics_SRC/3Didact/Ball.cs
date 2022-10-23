using MV;
using System.Drawing;

namespace Balls6
{
    // Ball mit gleichförmiger Geschwindigkeit 
    // !!ohne!! Reibung und Gravitation
    public class Ball : GraphicObject
    {
        #region Member Variablen
        public Vect2D m_V = new Vect2D();
        public int HighLigtCnt;
        const int BALL_RADIUS = 10;
        #endregion

        public Vect2D V
        {
            get { return m_V; }
            set { m_V = value; }
        }

        public Ball() : base() { }

        public Ball(Point aPos, Color aCol, double aV, double aDirection)
      : base(aPos, aCol)
        {
            m_V.SetFrom_R_Phi(aV, aDirection);
        }

        public override double GetRadius()
        {
            return BALL_RADIUS;
        }

        public override Size GetSize()
        {
            return new Size(2 * BALL_RADIUS, 2 * BALL_RADIUS);
        }

        #region Bewegungssimulation
        ///<summary>Bewegt das Grafikobjekt um m_V   b.z.w einem anderen Algorithmus weiter</summary>
        public virtual void CalcNextPos()
        {
            //Xn+1 = Vn*dt + Xn;
            m_Pos.AddTo(m_V, Par.DT);
        }

        ///<summary>Wird vom BallManager aufgerufen wenn eine Reflexion aufgetreten ist um z.B 
        /// Geschwindigkeitsverlust durch Reflexion zu modellieren </summary>
        public virtual void WasReflected()
        {
        }

        public virtual bool CollideWithBall(Ball aB)
        {
            return false;
        }
        #endregion

        #region Paint
        ///<summary>Das Grafikobjekt zeichen</summary>
        public override void PaintVisible(Graphics g)
        {
            if (HighLigtCnt > 0)
            {
                foregBrush.Color = Color.Red;
                HighLigtCnt--;
            }
            else
                foregBrush.Color = m_Color;
            g.FillEllipse(foregBrush, m_Pos.XI - BALL_RADIUS, GetInvertedYPos() - BALL_RADIUS,
                                      2 * BALL_RADIUS, 2 * BALL_RADIUS);
        }

        ///<summary>Das Grafikobjekt durch zeichen in der Hintergrundfarbe löschen</summary>
        public override void PaintInVisible(Graphics g)
        {
            // g.FillEllipse(backgBrush, m_Pos.XI, GetInvertedYPos(), BALL_RADIUS,BALL_RADIUS);
            g.FillEllipse(backgBrush, m_Pos.XI - BALL_RADIUS, GetInvertedYPos() - BALL_RADIUS,
                                      2 * BALL_RADIUS, 2 * BALL_RADIUS);
        }
        #endregion

        #region Reflexion an festen Hindernissen
        ///<summary>An einem rechteckigen senkrechten Objekt, welches sich rechts
        /// von der momentanen Ballposition befindet reflektieren</summary>
        public bool ReflectAtRightBorder(int aBorderPosX, int aBorderPosY, int aBorderHeight)
        {
            // selber bauen
            return false;
        }

        ///<summary>Berechnet die im übergebenen Rechteck auftretende Reflexion
        /// gibt true zurück falls eine  Reflexion auftritt</summary>
        public bool ReflectInWindow(Size aSz)
        {
            if ((m_Pos.X < 0) && (m_V.X < 0))
            { m_V.X = -m_V.X; return true; }

            if ((m_Pos.X > aSz.Width) && (m_V.X > 0))
            { m_V.X = -m_V.X; return true; }

            if ((m_Pos.Y < BALL_RADIUS) && (m_V.Y < 0))
            { m_V.Y = -m_V.Y; return true; }

            if ((m_Pos.Y > aSz.Height) && (m_V.Y > 0))
            { m_V.Y = -m_V.Y; return true; }

            return false;
        }

        ///<summary>In einem rechts offenen Rechteck reflektieren</summary>
        public bool ReflectInWindowOR(Size aSz)
        {
            // selber bauen
            return false;
        }
        #endregion
    }
}
