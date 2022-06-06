
using System;
using System.Drawing;
using MV;

namespace HLSpaceShip
{
  class SpeedArrowObject
  {
    #region Member Variablen
    protected Vect2D _tmp;
    protected static Pen _arrowPen = new Pen(Color.Green, 3);
    #endregion
    // Properties
    public Vect2D Pos;
    public Vect2D V; // current speed and Direction
    
    public SpeedArrowObject()
    {
      Pos.SetXY(0, 0);
      V.SetFrom_R_Phi(10, 0);
    }

    public void Rotate(double aPhi)
    {
      _tmp.SetFrom_R_Phi(1, aPhi);
      V.CoMultTo(_tmp);
    }

    // Xn+1 = Xn + V*dt
    public void CalcNextPos()
    {
      // Pos.AddTo(V);
      Pos.AddTo(V, Par.DT);
    }

    public void Paint(Graphics gr)
    {
      _tmp = V * 3.0;
      _tmp = Pos + _tmp;
      gr.DrawLine(_arrowPen, Pos.AsPoint, _tmp.AsPoint);
    }
  }


  // _relPoints beschreibt ein Vektorgrafik-Objekt
  // relativ zur momentanen Position Pos des Objekts
  // durch die Rotation von _relPoints um den relativen
  // Koordinatenursprung Pos kann die Richtung des RotGraphicObj geändert werden
  class RotatingGraphicObject : SpeedArrowObject
  {
    Vect2D[] _relPoints; // relative to Pos
    Point[] _absPoints; // absolute Points for drawing
    
    public RotatingGraphicObject() : base()
    {
      _relPoints = new Vect2D[4];
      _absPoints = new Point[4];
      InitFigure();
    }
    
    public void InitFigure()
    {
      /* _relPoints[0].SetXY(20, 0);
      _relPoints[1].SetXY(-20, -15);
      _relPoints[2].SetXY(-20, +15); */
      _relPoints[0].SetXY(40, 40);
      _relPoints[1].SetXY(40, -40);
      _relPoints[2].SetXY(-40, -40);
      _relPoints[3].SetXY(-40, 40);
    }
    
    new public void Rotate(double aPhi)
    {
      base.Rotate(aPhi);
      for (int i = 0; i < _relPoints.Length; i++)
        _relPoints[i].CoMultTo(_tmp);
    }

    new public void Paint(Graphics gr)
    {
      CalcAbsCoordinates();
      // foreach( Point pt in _absPoints )
      // gr.FillEllipse(Brushes.Red, pt.X-2, pt.Y-2, 4, 4);
      gr.DrawLines(Pens.Red, _absPoints);
      gr.DrawLine(Pens.Red, _absPoints[3], _absPoints[0]);
      base.Paint(gr);
    }

    void CalcAbsCoordinates()
    {
      for (int i = 0; i < _relPoints.Length; i++)
      {
        _tmp = _relPoints[i] + Pos;
        _absPoints[i] = _tmp.AsPoint;
      }
    }
  }
}
