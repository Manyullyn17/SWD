
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace HLSpaceShip
{
  public partial class Form1 : Form
  {
    DiffDrive car;
    StickControl.StickControlForm stick;

    public Form1()
    {
      InitializeComponent();
      timer1.Enabled = false; timer1.Interval = Par.TIMER_INTERVAL;
      _scaleEd.Text = "1,0";
      car = new DiffDrive();
      stick = new StickControl.StickControlForm();
    }

    protected override void OnLoad(EventArgs e)
    {
      stick.Show();
      timer1.Enabled = true;
    }

    void OnScaleEditKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 13)
      {
        _panel.ScaleFactor = float.Parse(_scaleEd.Text);
        _panel.Invalidate();
      }
    }

    void OnPanelPaint(object sender, PaintEventArgs e)
    {
      car.Paint(e.Graphics);
    }

    void OnPanelMouseMove(object sender, MouseEventArgs e)
    {
      // Point pt = _panel.Device2World(e.Location);
      // _infoLbl.Text = pt.ToString() + " " + _panel.Ymin.ToString();
    }

    void OnResetBtn(object sender, EventArgs e)
    {
      car.Reset();
    }

    void OnTimer(object sender, EventArgs e)
    {
      if (stick.Check())
      {
        double speed = stick.GetYVal() * 0.2;
        if (speed == 0.0)
          speed = 0.001;
        car.SetV(speed);
        car.dPhi.SetFrom_R_Phi(1, -stick.GetXVal() * 0.1 * Par.DT);
      }
      car.CalcNextPos();
      car.UpdatePath();
      _panel.Invalidate();
    }

    void OnRunCheckChanged(object sender, EventArgs e)
    {
      /* if (_runChk.Checked)
        timer1.Enabled = true;
      else
        timer1.Enabled = false; */
      _scaleEd.Focus();
    }

    void OnSpeedEditKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue != 13)
        return;
      string[] words = _SpeedEd.Text.Split(':');
      double speed = double.Parse(words[0]);
      double omega = double.Parse(words[1]);
      car.SetV(speed);
      car.dPhi.SetFrom_R_Phi(1, omega * Par.DT);
    }
  }
}