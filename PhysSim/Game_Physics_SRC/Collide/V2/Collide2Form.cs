
using System;
// using System.Data;
using System.Windows.Forms;
using System.Drawing;
using MV;

namespace Collide
{
  public partial class Collide2Form : Form
  {
    public Ball b1 = new Ball();
    public Ball b2 = new Ball();

    public Collide2Form()
    {
      InitializeComponent();
      timer1.Enabled = false; timer1.Interval = Par.TIMER_INTERVAL;
      _Ed1.Text = "0: 60:135: 60:45";
      PlaceBalls2();
    }

    void OnPanelMouseMove(object sender, MouseEventArgs e)
    {
      // Point pt = _panel.Device2World(e.Location);
      // _infoLbl.Text = pt.ToString() + " " + _panel.Ymin.ToString();
    }

    void OnTimer(object sender, EventArgs e)
    {
      
    }
    
    void OnRunCheckChanged(object sender, EventArgs e)
    {
      
    }
    
    void OnEditKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue != 13)
        return;
      PlaceBalls2();
      _panel.Invalidate();
    }

    void PlaceBalls1()
    {
      string[] words = _Ed1.Text.Split(':');
      double alpha = double.Parse(words[0]);
      double beta = double.Parse(words[1]);
      
      b1.pos.SetFrom_R_Phi(30, alpha);
      b2.pos = b1.pos.GetOppositeDirection();
      
      Vect2D r1 = Vect2D.Create(1, alpha, true);
      b1.V.SetFrom_R_Phi(60, beta);
      b2.V = b1.V; b2.V.X = -b1.V.X;
      b1.V.CoMultTo(r1); b2.V.CoMultTo(r1);
    }

    void PlaceBalls2()
    {
      string[] words = _Ed1.Text.Split(':');
      double phiImp = double.Parse(words[0]);
      double v1 = double.Parse(words[1]);
      double phi1 = double.Parse(words[2]);
      double v2 = double.Parse(words[3]);
      double phi2 = double.Parse(words[4]);

      b1.pos.SetFrom_R_Phi(30, phiImp);
      b2.pos = b1.pos.GetOppositeDirection();

      b1.V.SetFrom_R_Phi(v1, phi1); b2.V.SetFrom_R_Phi(v2, phi2);
      Vect2D r1 = Vect2D.Create(1, phiImp, true);
      b1.V.CoMultTo(r1); b2.V.CoMultTo(r1);
    }

    void OnPanelPaint(object sender, PaintEventArgs e)
    {
      Graphics gr = e.Graphics;
      b1.Paint(gr); b2.Paint(gr);
      
      Line2D sdir = Line2D.ini;
      sdir.InitMid(b1.pos, b2.pos);
      Line2D ndir = sdir.GetNormalLine();
      // sdir.Paint1(gr, 80);
      ndir.Paint1(gr, 80);
    }

    void OnCollideBtn(object sender, EventArgs e)
    {
      Collider.Collide1(b1, b2);
      _Ed1.Focus();
      _panel.Invalidate();
    }
  }
}