
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
// using System.Collections.Generic;
// using System.Text;
using System.Windows.Forms;


namespace satellite
{
    class ScPanel : Panel
    {
        Matrix m_invY = new Matrix(1, 0, 0, -1, 0, 0);
        int m_Xmin, m_Xmax, m_Ymin, m_Ymax;
        const int X_GRID = 50;
        const int Y_GRID = 50;
        Pen m_DashPen = new Pen(Color.Blue);
        Graphics m_gr = null;
        float m_ScaleFact = 1.0F;
        Point[] m_PtAry = new Point[1];

        public ScPanel() : base()
        {
            m_DashPen.DashStyle = DashStyle.DashDotDot;
        }

        public void Init()
        {
            this.DoubleBuffered = true;
        }

        public float ScaleFactor
        {
            set { m_ScaleFact = value; }
        }

        public Point Device2World(Point aP)
        {
            m_PtAry[0] = aP;
            Graphics gr = this.CreateGraphics(); SetWorldCoordinates(gr);
            gr.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, m_PtAry);
            return m_PtAry[0];
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            m_gr = e.Graphics;
            SetWorldCoordinates(m_gr);
            // DrawGrid();
            base.OnPaint(e);
        }

        void SetWorldCoordinates(Graphics gr)
        {
            m_Xmax = (int)(((Size.Width / 2) - 20) / m_ScaleFact); m_Xmin = -m_Xmax;
            m_Ymax = (int)(((Size.Height / 2) - 20) / m_ScaleFact); m_Ymin = -m_Ymax;
            gr.ScaleTransform(m_ScaleFact, m_ScaleFact, MatrixOrder.Prepend);
            // m_gr.Transform = m_invY;
            gr.MultiplyTransform(m_invY, MatrixOrder.Append);
            gr.TranslateTransform(Size.Width / 2, Size.Height / 2, MatrixOrder.Append);
        }

        void DrawGrid()
        {
            m_gr.DrawLine(Pens.Blue, m_Xmin, 0, m_Xmax, 0);
            m_gr.DrawLine(Pens.Blue, 0, m_Ymin, 0, m_Ymax);
            int x;
            for (x = 0; x >= m_Xmin; x -= X_GRID)
                m_gr.DrawLine(m_DashPen, x, m_Ymin, x, m_Ymax);
            for (x = 0; x <= m_Xmax; x += X_GRID)
                m_gr.DrawLine(m_DashPen, x, m_Ymin, x, m_Ymax);
            int y;
            for (y = 0; y >= m_Ymin; y -= X_GRID)
                m_gr.DrawLine(m_DashPen, m_Xmin, y, m_Xmax, y);
            for (y = 0; y <= m_Ymax; y += X_GRID)
                m_gr.DrawLine(m_DashPen, m_Xmin, y, m_Xmax, y);
        }

    }
}
