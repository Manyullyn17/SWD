using System;
using System.Drawing;
using System.Collections.Generic;
using MV;

namespace HLSpaceShip
{
  class BaseSpaceShip
  {
    #region Member Variablen
    protected static Pen _speedPen = new Pen(Color.Green, 3);
    #endregion
    // Properties
    public Vect2D Pos;
    public Vect2D V; // current speed
    public Vect2D dPhi; // Rotational Speed  Omega
    public Vect2D Heading; // Direction of the Nose of the Ship
    public BaseSpaceShip()
    {
      Reset();
    }

    public void Reset()
    {
      Pos.SetXY(0, 0);
      V.SetXY(0.01, 0);
      Heading.SetXY(1, 0);
      dPhi.SetFrom_R_Phi(1, 0);
    }

    public void Paint(Graphics gr)
    {
      Vect2D endPoint;
      endPoint = V * 5.0;
      endPoint = Pos + endPoint;
      gr.DrawLine(_speedPen, Pos.AsPoint, endPoint.AsPoint);
    }
  }


  class SpaceShip : BaseSpaceShip
  {
    #region VectorGraphic
    Vect2D _oldPos;
    Vect2D[] _relPoints; // relative to Pos
    Point[] _absPoints; // absolute Points for drawing
    const int NUM_POINTS = 3;
    LinkedList<Point> _path = new LinkedList<Point>();
    #endregion

    public SpaceShip() : base()
    {
      _relPoints = new Vect2D[NUM_POINTS];
      _absPoints = new Point[NUM_POINTS];
      Reset();
    }

    new public void Reset()
    {
      base.Reset();
      _relPoints[0].SetXY(30, 0);
      _relPoints[1].SetXY(-30, -20);
      _relPoints[2].SetXY(-30, +20);
      _path.Clear();
    }

    // rotate picture (Vector-Graphic) of the ship by dPhi
    public void Rotate()
    {
      for (int i = 0; i < _relPoints.Length; i++)
        _relPoints[i].CoMultTo(dPhi);
    }

    new public void Paint(Graphics gr)
    {
      CalcAbsCoordinates();
      gr.DrawLines(Pens.Red, _absPoints);
      gr.DrawLine(Pens.Red, _absPoints[NUM_POINTS-1], _absPoints[0]);
      // pfad anzeigen
      foreach (Point pt in _path)
        gr.FillEllipse(Brushes.Red, pt.X - 2, pt.Y - 2, 4, 4);
      base.Paint(gr);
    }

    void CalcAbsCoordinates()
    {
      Vect2D pointPos;
      for (int i = 0; i < _relPoints.Length; i++)
      {
        pointPos = _relPoints[i] + Pos;
        _absPoints[i] = pointPos.AsPoint;
      }
    }

    public void UpdatePath()
    {
      if (Pos.DistBetweenPoints(_oldPos) < 10)
        return;
      _oldPos = Pos;
      if (_path.Count > 50)
        _path.RemoveLast();
      _path.AddFirst(Pos.AsPoint);
    }
  }


  // Robot with Diff-Drive
  class DiffDrive : SpaceShip
  {
    double _speed; // Betrag und Vorzeichen des V-Vektors

    public DiffDrive() : base()
    {
    }

    public void SetV(double aSpeed)
    {
      if (_speed < 0.0 && aSpeed>0)
      {
        _speed = aSpeed;
        V.Set_R(-aSpeed);
      }
      else if (_speed < 0.0 && aSpeed < 0)
      {
        _speed = aSpeed;
        V.Set_R(-aSpeed);
      }
      else
      {
        _speed = aSpeed;
        V.Set_R(aSpeed);
      }
    }

    new public void CalcNextPos()
    {
      base.Rotate(); // _relPoints rotieren ( Frame rotieren )
      Heading.CoMultTo(dPhi);
      V.CoMultTo(dPhi); // Vn+1 = Vn rot dPhi;
      Pos.AddTo(V, Par.DT); // Pos(n+1) = Pos(n) + V(n)*dt
      // wenn rechts raus links wieder rein
      ScPanel.thePanel.CorrigatePosition(ref Pos);
    }
  }
}
