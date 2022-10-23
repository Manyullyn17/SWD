using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Balls6
{
    public class GridPanel : Panel
    {
        const int X_GRID = 50;
        const int Y_GRID = 50;
        Pen m_DashPen = new Pen(Color.Blue);

        public GridPanel() : base()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            m_DashPen.DashStyle = DashStyle.DashDotDot;
            // this.DoubleBuffered = true;
        }

        public static Point Snap2Grid(Point aPos)
        {
            aPos.X = (aPos.X / X_GRID) * X_GRID;
            aPos.Y = (aPos.Y / Y_GRID) * Y_GRID;
            return aPos;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            base.OnPaint(e);
        }

        void DrawGrid(Graphics gr)
        {
            /* for(int x = Size.Width; x > 0; x -= X_GRID)
              gr.DrawLine(m_DashPen, x, 0, x, Size.Height); */
            for (int x = 0; x < Size.Width; x += X_GRID)
                gr.DrawLine(m_DashPen, x, 0, x, Size.Height);
            for (int y = Size.Height; y > 0; y -= Y_GRID)
                gr.DrawLine(m_DashPen, 0, y, Size.Width, y);
            /* for( int y = 0; y < Size.Height; y += Y_GRID )
              gr.DrawLine(m_DashPen, 0, y, Size.Width, y); */
        }
    }
}
