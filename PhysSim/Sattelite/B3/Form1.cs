using MV;
using System;
// using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace satellite
{
    public partial class Form1 : Form
    {
        private double m_Speed, m_Direction;
        Satellite m_Earth, m_Sat;

        public Form1()
        {
            InitializeComponent();
            m_pnl.Init();
            Satellite.SetDefaultColors(this.BackColor, Color.Red);
            m_Earth = new Satellite(new Point(0, 0), Color.Red, 0, 0);
            m_Earth.Radius = 20;
            timer1.Interval = 20; timer1.Start();
            m_ZoomTrk.Value = 100;
            m_Ed1.Text = "500  0";
        }

        void SpeedAndDirFromText()
        {
            string txt, str1, str2;
            int p1;

            txt = m_Ed1.Text; txt += "  ";
            for (p1 = 0; txt[p1] != ' '; p1++)
            {
                if (p1 >= txt.Length)
                    return;
            }
            str1 = txt.Substring(0, p1);
            str2 = txt.Substring(p1);

            m_Speed = double.Parse(str1); m_Direction = double.Parse(str2);
        }

        private void OnPanelPaint(object sender, PaintEventArgs e)
        {
            m_Earth.PaintVisible(e.Graphics);
            if (m_Sat != null)
                m_Sat.PaintVisible(e.Graphics);
        }

        void CalcNextPositions()
        {
            Vect2D rVect, acc;
            double rDist;
            for (int i = 0; i < Par.ITER_PER_TICK; i++)
            {
                // Vector von der Erde zum Satteliten
                rVect = m_Earth.VectBetweenObjects(m_Sat);

                rDist = rVect.GetR(); // Abstand  Erde Sattelit

                // rVect auf 1 normiert ( Länge == 1 )
                rVect = rVect.ScalarMult(1 / rDist);

                // Gravitationsvektor der auf den Sat wirkt m*g/r^2
                acc = rVect.ScalarMult(Par.EARTH_ACCEL / (rDist * rDist));

                // Vn+1 = Vn - acc*DT
                m_Sat.m_V.SubFrom(acc);

                // Xn+1 = Xn + Vn*DT
                m_Sat.IntegratePosition();
            }
            m_Sat.AddTracePoint();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (m_RunChk.Checked)
            {
                CalcNextPositions();
                m_pnl.Invalidate();
            }
        }

        void OnStepButt(object sender, EventArgs e)
        {
            m_RunChk.Checked = false;
            CalcNextPositions();
            m_pnl.Invalidate();
        }

        private void OnPanelMouseDown(object sender, MouseEventArgs e)
        {
            Point pos = m_pnl.Device2World(e.Location);
            SpeedAndDirFromText();
            m_Speed /= Par.ITER_PER_TICK;
            m_Sat = new SatelliteWithTrace(pos, Color.Blue, m_Speed, m_Direction);
            m_pnl.Invalidate();
        }

        private void OnZoomChanged(object sender, EventArgs e)
        {
            float val = ((float)m_ZoomTrk.Value / 100.0F);
            m_lbl2.Text = val.ToString();
            m_pnl.ScaleFactor = val;
            m_pnl.Invalidate();
        }
    }
}
