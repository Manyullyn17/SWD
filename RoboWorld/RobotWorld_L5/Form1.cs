using System;
// using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RobotWorld
{
    public partial class Form1 : DblBuffForm
    {
        public Form1() : base()
        {
            InitializeComponent();
            timer1.Enabled = false; timer1.Interval = Par.TIMER_INTERVAL;
            _prgNumEd.Text = "1 : 0";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            RobotMgr.CleanUp();
            base.OnFormClosing(e);
        }

        void OnSimOnOffMenue(object sender, EventArgs e)
        {
            timer1.Enabled = simOnOffMenu.Checked;
        }

        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (!createRobotsMenue.Checked)
                label1.Text = RobotMgr.GetInfo(e.Location);
            if (suspendMenue.Checked)
                RobotMgr.SwitchSuspRes(e.Location);
            if (createObstaclesMenu.Checked)
                Omgr.NewObstacle(e.Location);
            else if (createRobotsMenue.Checked)
            {
                string[] words = new String[2];
                words = _prgNumEd.Text.Split(':');
                RobotMgr.CreateRobot(int.Parse(words[0]), e.Location, double.Parse(words[1]));
            }
            this.Invalidate();
        }

        void OnTimer(object sender, EventArgs e)
        {
            for (int i = 0; i < Par.ITER_PER_TICK; i++)
                RobotMgr.CalcNextPos();
            MapMousePos();

            RobotMgr.UpdatePath(); // Spur-Anzeige
            RobotProg.SignalRobots(); // Robot-Progs von der Änderung benachrichtigen

            this.Invalidate();
        }

        void MapMousePos()
        {
            Point mp = PointToClient(Control.MousePosition);
            if (mp.X < 0)
                mp.X = this.Width;
            if (mp.Y < 0)
                mp.Y = this.Height / 2;
            RobotProg.mpos.AsPoint = mp;
        }

        void OnPaint(object sender, PaintEventArgs e)
        {
            RobotMgr.Paint(e.Graphics);
            Omgr.Paint(e.Graphics);
        }

        void OnTraceMenue(object sender, EventArgs e)
        {
            Par.showPath = traceMenueItm.Checked;
        }
    }
}
