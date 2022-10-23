using MV;
using System.Drawing;


namespace satellite
{
    public class Satellite : GraphicObject
    {
        #region Member Variablen
        public Vect2D m_V;
        int m_Radius = 10;
        #endregion

        public Vect2D V
        {
            get { return m_V; }
            set { m_V = value; }
        }

        public int Radius
        {
            get { return m_Radius; }
            set { m_Radius = value; }
        }

        public Satellite() : base() { }

        public Satellite(Point aPos, Color aCol, double aV, double aDirection)
          : base(aPos, aCol)
        {
            m_V.SetFrom_R_Phi(aV, aDirection);
        }

        public override double GetRadius() { return m_Radius; }

        public override Size GetSize() { return new Size(2 * m_Radius, 2 * m_Radius); }

        public virtual void IntegratePosition()
        {
            // m_Pos.AddTo(m_V);
            m_Pos.AddTo(m_V, Par.DT);
        }

        public virtual void AddTracePoint()
        {
        }

        public override void PaintVisible(Graphics g)
        {
            foregBrush.Color = m_Color;
            g.FillEllipse(foregBrush, m_Pos.XI - m_Radius, m_Pos.YI - m_Radius,
                                      2 * m_Radius, 2 * m_Radius);
        }

        public override void PaintInVisible(Graphics g)
        {
            g.FillEllipse(backgBrush, m_Pos.XI - m_Radius, m_Pos.YI - m_Radius,
                                      2 * m_Radius, 2 * m_Radius);
        }
    }
}
