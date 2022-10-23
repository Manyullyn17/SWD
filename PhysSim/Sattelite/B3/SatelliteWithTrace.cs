using System.Collections;
using System.Drawing;


namespace satellite
{
    public class SatelliteWithTrace : Satellite
    {
        ArrayList m_TracePoints = new ArrayList();
        const int MAX_TRC_POINTS = 500; // 500
        int m_TraceCntr = 0;

        public SatelliteWithTrace() : base() { }

        public SatelliteWithTrace(Point aPos, Color aCol, double aV, double aDirection)
          : base(aPos, aCol, aV, aDirection)
        {
        }

        public override void AddTracePoint()
        {
            m_TraceCntr++;
            if (m_TraceCntr > 1) // 3
            {
                m_TraceCntr = 0;
                Point pt = m_Pos.AsPoint;
                m_TracePoints.Add(pt);
                if (m_TracePoints.Count > MAX_TRC_POINTS)
                    m_TracePoints.RemoveAt(0);
            }
        }

        public override void PaintVisible(Graphics g)
        {
            base.PaintVisible(g);
            DrawPointTrace(g);
        }

        private void DrawPointTrace(Graphics g)
        {
            Point pt2;
            foreach (Point pt in m_TracePoints)
            {
                pt2 = pt;
                g.FillEllipse(foregBrush, pt2.X - 2, pt2.Y - 2, 2 * 2, 2 * 2);
            }
        }

        private void DrawLineTrace(Graphics g)
        {
            Point pt1, pt2;
            for (int i = 0; i < m_TracePoints.Count - 1; i++)
            {
                pt1 = (Point)m_TracePoints[i];
                pt2 = (Point)m_TracePoints[i + 1];
                g.DrawLine(foregPen, pt1, pt2);
            }
        }

    }
}











