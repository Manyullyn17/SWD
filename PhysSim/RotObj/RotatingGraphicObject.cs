// using System.Collections.Generic;
// using System.Text;
using MV;
using System.Drawing;

namespace RotObj
{
    // V und Heading sind der gleiche Vektor
    class SpeedArrowObject
    {
        #region Member Variablen
        protected Vect2D _dPhi;
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

        public void InitFigure()
        {
        }

        public void Rotate(double aPhi)
        {
            _dPhi.SetFrom_R_Phi(1, aPhi);
            // V = V * _dPhi
            V.CoMultTo(_dPhi);
        }

        // Xn+1 = Xn + V*dt
        public void CalcNextPos()
        {
            Pos.AddTo(V);
        }

        public void Paint(Graphics gr)
        {
            Vect2D tmp;
            tmp = V * 3.0; // V-Vektor für die Anzeige künstlich verlängern
            tmp = Pos + tmp;
            // tmp ist der Ortsvektor zum Endpunkt des Geschwindigkeitspfeils
            gr.DrawLine(_arrowPen, Pos.AsPoint, tmp.AsPoint);
        }
    }


    // _relPoints beschreibt ein Vektorgrafik-Objekt
    // relativ zur momentanen Position Pos des Objekts
    // durch die Rotation von _relPoints um den relativen
    // Koordinatenursprung Pos kann die Richtung des RotGraphicObj geändert werden
    class RotatingGraphicObject : SpeedArrowObject
    {
        Vect2D[] _relPoints; // relative to Pos
        Point[] _absPoints; // absolute Points for drawing = Pos + _relPoints
        const int N_P = 3;

        public RotatingGraphicObject() : base()
        {
            _relPoints = new Vect2D[N_P];
            _absPoints = new Point[N_P];
            InitFigure();
        }

        new public void InitFigure()
        {
            _relPoints[0].SetXY(30, 0);
            _relPoints[1].SetXY(-30, -20);
            _relPoints[2].SetXY(-30, +20);

            /* _relPoints[0].SetXY(40, 40);
            _relPoints[1].SetXY(40, -40);
            _relPoints[2].SetXY(-40, -40);
            _relPoints[3].SetXY(-40, 40); */
        }

        // von der momentanen Orientierung ausgehend um aPhi drehen
        new public void Rotate(double aPhi)
        {
            base.Rotate(aPhi);
            for (int i = 0; i < _relPoints.Length; i++)
                _relPoints[i].CoMultTo(_dPhi);
        }

        new public void Paint(Graphics gr)
        {
            CalcAbsCoordinates();
            gr.DrawLines(Pens.Red, _absPoints);
            gr.DrawLine(Pens.Red, _absPoints[N_P - 1], _absPoints[0]);
            base.Paint(gr);
        }

        void CalcAbsCoordinates()
        {
            for (int i = 0; i < _relPoints.Length; i++)
            {
                Vect2D tmp;
                tmp = _relPoints[i] + Pos;
                _absPoints[i] = tmp.AsPoint;
            }
        }
    }
}
