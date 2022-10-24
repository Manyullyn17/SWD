using MV;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Collide
{
    public partial class Collide3Form : Form
    {
        BallMgr mgr = new BallMgr();
        int state = 1;
        int ballnr = 0;
        Point dirLineEnd;
        Size WndSize;
        double tmpSpeed;

        public Collide3Form()
        {
            InitializeComponent();
            timer1.Enabled = false; timer1.Interval = Par.TIMER_INTERVAL;
            _Ed1.Text = "100";
            WndSize.Width = _panel.Size.Width;
            WndSize.Height = _panel.Size.Height;
            mgr.WndSize = WndSize;
            _panel.Invalidate();
        }

        void OnPanelMouseDown(object sender, MouseEventArgs e)
        {
            Point pt = _panel.Device2World(e.Location);
            if (state == 1)
            {
                state = 2;
                mgr.b[ballnr++] = new Ball(pt, ballnr);
                _panel.Invalidate();
                return;
            }
            if (state == 2)
            {
                if (ballnr == 10)
                    state = 3;
                mgr.b[ballnr++] = new Ball(pt, ballnr);
                _panel.Invalidate();
                return;
            }
            if (state == 3)
            {
                state = 5;
                ballnr = 0;
                dirLineEnd = pt;
                for (int i = 0; i < 11; i++)
                    SetSpeed(mgr.b[i]);
                SetMass();
                _panel.Invalidate();
                return;
            }
        }

        void OnPanelMouseMove(object sender, MouseEventArgs e)
        {
            if (state == 3)
            {
                Vect2D lineEnd = new Vect2D();
                lineEnd.SetXY(dirLineEnd.X, dirLineEnd.Y);
                dirLineEnd = _panel.Device2World(e.Location);
                tmpSpeed = Vect2D.VectBetweenPoints(mgr.b[0].pos.AsPoint, dirLineEnd).VectLength() / 1500 * Convert.ToInt32(_Ed1.Text);
                _spdLbl.Text = "Speed: " + tmpSpeed.ToString();
                _panel.Invalidate();
            }
        }

        void SetSpeed(Ball ba)
        {
            double speed = 0;
            if (ba == mgr.b[0])
                speed = tmpSpeed;
            Vect2D v = Vect2D.VectBetweenPoints(ba.pos.AsPoint, dirLineEnd);
            ba.V = v.GetScaledVersion(speed);
        }

        void SetMass()
        {
            for (int i = 0; i < 11; i++)
                mgr.b[i].m = 1;
        }

        void OnTimer(object sender, EventArgs e)
        {
            if (state != 5)
                return;
            mgr.CalcNextPositions();
            label2.Text = mgr.b[0].V.VectLength().ToString();
            for (int i = 0; i < 11; i++)
            {
                if (mgr.b[i].V.VectLength() > 0)
                    break;
                if (i == 10)
                    state = 3;
            }
            _panel.Invalidate();
        }

        void OnEditKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13)
                return;
        }

        void OnPanelPaint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            mgr.Paint(gr);
            if (state == 3)
            {
                gr.DrawLine(Pens.Red, mgr.b[0].pos.AsPoint, dirLineEnd);
            }
        }

        void OnResetBtn(object sender, EventArgs e)
        {
            state = 1;
            ballnr = 0;
            _runChk.Checked = false; timer1.Enabled = false;
            mgr.ClearList();
            _panel.Invalidate();
        }

        void OnRunCheckChanged(object sender, EventArgs e)
        {
            if (_runChk.Checked)
                timer1.Enabled = true;
            else
                timer1.Enabled = false;
        }

        void OnResize(object sender, EventArgs e)
        {
            WndSize.Width = _panel.Size.Width;
            WndSize.Height = _panel.Size.Height;
            mgr.WndSize = WndSize;
            _panel.Invalidate();
        }

        void OnLoadBtnClicked(object sender, EventArgs e)
        {
            OnResetBtn(null, null);
            mgr.b[0] = new Ball(137 - WndSize.Width / 2, 288 - WndSize.Height / 2, 1);
            mgr.b[1] = new Ball(637 - WndSize.Width / 2, 288 - WndSize.Height / 2, 2);
            mgr.b[2] = new Ball(672 - WndSize.Width / 2, 263 - WndSize.Height / 2, 3);
            mgr.b[3] = new Ball(672 - WndSize.Width / 2, 312 - WndSize.Height / 2, 4);
            mgr.b[4] = new Ball(707 - WndSize.Width / 2, 243 - WndSize.Height / 2, 5);
            mgr.b[5] = new Ball(707 - WndSize.Width / 2, 288 - WndSize.Height / 2, 6);
            mgr.b[6] = new Ball(707 - WndSize.Width / 2, 333 - WndSize.Height / 2, 7);
            mgr.b[7] = new Ball(742 - WndSize.Width / 2, 218 - WndSize.Height / 2, 8);
            mgr.b[8] = new Ball(742 - WndSize.Width / 2, 263 - WndSize.Height / 2, 9);
            mgr.b[9] = new Ball(742 - WndSize.Width / 2, 312 - WndSize.Height / 2, 10);
            mgr.b[10] = new Ball(742 - WndSize.Width / 2, 357 - WndSize.Height / 2, 11);
            state = 3;
        }
    }
}
