
using System;
using System.Windows.Forms;
using System.Drawing;
using MV;

namespace Collide
{
  public partial class Collide3Form : Form
  {
    BallMgr mgr = new BallMgr();
    int state = 1;
    Point dirLineEnd;
    
    public Collide3Form()
    {
      InitializeComponent();
      timer1.Enabled = false; timer1.Interval = Par.TIMER_INTERVAL;
      _Ed1.Text = "1:2:1:2";
    }

    void OnPanelMouseDown(object sender, MouseEventArgs e)
    {
      Point pt = _panel.Device2World(e.Location);
      if (state == 1)
      {
        state = 2;
        mgr.b1 = new Ball(pt);
        SetMass(mgr.b1, 0);
        _panel.Invalidate();
        return;
      }
      if (state == 2)
      {
        state = 3;
        mgr.b2 = new Ball(pt);
        SetMass(mgr.b2, 2);
        _panel.Invalidate();
        return;
      }
      if (state == 3)
      {
        state = 4;
        dirLineEnd = pt;
        SetSpeed(mgr.b1,1);
        _panel.Invalidate();
        return;
      }
      if (state == 4)
      {
        state = 5;
        dirLineEnd = pt;
        SetSpeed(mgr.b2,3);
        _panel.Invalidate();
        return;
      }
    }

    void OnPanelMouseMove(object sender, MouseEventArgs e)
    {
      if (state == 3 || state == 4)
      {
        dirLineEnd = _panel.Device2World(e.Location);
        _panel.Invalidate();
      }
    }

    void SetSpeed(Ball ba, int i)
    {
      string[] words = _Ed1.Text.Split(':');
      double speed = double.Parse(words[i]);
      Vect2D v = Vect2D.VectBetweenPoints(ba.pos.AsPoint, dirLineEnd);
      ba.V = v.GetScaledVersion(speed);
    }

    void SetMass(Ball ba, int i)
    {
      string[] words = _Ed1.Text.Split(':');
      ba.m = int.Parse(words[i]);
    }

    void OnTimer(object sender, EventArgs e)
    {
      if (state != 5)
        return;
      mgr.CalcNextPositions();
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
        gr.DrawLine(Pens.Red, mgr.b1.pos.AsPoint, dirLineEnd);
      }
      if (state == 4)
      {
        gr.DrawLine(Pens.Red, mgr.b2.pos.AsPoint, dirLineEnd);
      }
    }

    void OnResetBtn(object sender, EventArgs e)
    {
      state = 1;
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

    void OnReverseBtn(object sender, EventArgs e)
    {
      mgr.ReverseSpeed();
    }
  }
}