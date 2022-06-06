
using System;
// using System.Collections.Generic;
// using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MV
{
  class ScPanel : Panel
  {
    public static ScPanel thePanel;
    #region MemberVariablen
    Matrix m_invY = new Matrix(1, 0, 0, -1, 0, 0);
    int Xmin, Xmax, Ymin, Ymax;
    const int X_GRID = 50;
    const int Y_GRID = 50;
    Pen m_DashPen = new Pen(Color.Blue);
    float m_ScaleFact = 1.0F;
    Point[] m_PtAry = new Point[1];
    #endregion

    public ScPanel() : base()
    {
      this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
      ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
      m_DashPen.DashStyle = DashStyle.DashDotDot;
      thePanel = this;
    }

    /* public void Init()
    {
      this.DoubleBuffered = true;
    } */

    public float ScaleFactor
    {
      set { m_ScaleFact = value; }
    }

    // Bring Positions outside of ScPanel back into ScPanel
    // Pos > Xmax => Xmin; Pos < Xmin = > Xmax ......
    public void CorrigatePosition(ref Vect2D aPos)
    {
      if (aPos.X < Xmin)
        aPos.X = Xmax;
      if (aPos.X > Xmax)
        aPos.X = Xmin;
      if (aPos.Y < Ymin)
        aPos.Y = Ymax;
      if (aPos.Y > Ymax)
        aPos.Y = Ymin;
    }

    public Point Device2World(Point aP)
    {
      m_PtAry[0] = aP;
      Graphics gr = this.CreateGraphics(); SetWorldCoordinates(gr);
      gr.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, m_PtAry);
      return m_PtAry[0];
    }

    /* protected override void OnResize(EventArgs e)
    {
      Invalidate();
      base.OnResize(e);
    } */
    
    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics gr = e.Graphics;
      SetWorldCoordinates(gr);
      DrawGrid(gr);
      base.OnPaint(e);
    }
    
    void SetWorldCoordinates(Graphics gr)
    {
      Xmax = (int)(((Size.Width/2)-20)/m_ScaleFact);   Xmin = -Xmax;
      Ymax = (int)(((Size.Height/2)-20)/m_ScaleFact);  Ymin = -Ymax;
      gr.ScaleTransform(m_ScaleFact, m_ScaleFact, MatrixOrder.Prepend);
      // m_gr.Transform = m_invY;
      gr.MultiplyTransform(m_invY, MatrixOrder.Append);
      gr.TranslateTransform(Size.Width/2, Size.Height/2, MatrixOrder.Append);
    }

    void DrawGrid(Graphics gr)
    {
      gr.DrawLine(Pens.Blue, Xmin, 0, Xmax, 0);
      gr.DrawLine(Pens.Blue, 0, Ymin, 0, Ymax);
      int x;
      for (x = 0; x >= Xmin; x -= X_GRID)
        gr.DrawLine(m_DashPen, x, Ymin, x, Ymax);
      for (x = 0; x <= Xmax; x += X_GRID)
        gr.DrawLine(m_DashPen, x, Ymin, x, Ymax);
      int y;
      for (y = 0; y >= Ymin; y -= X_GRID)
        gr.DrawLine(m_DashPen, Xmin, y, Xmax, y);
      for (y = 0; y <= Ymax; y += X_GRID)
        gr.DrawLine(m_DashPen, Xmin, y, Xmax, y);
    }

  }
}
