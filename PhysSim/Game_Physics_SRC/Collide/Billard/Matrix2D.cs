
using System;
using System.Drawing;

// V2.0
namespace MV
{
    public struct Matrix2D
    {
        #region Member Variablen
        public double a11, a12, a21, a22;
        static Matrix2D m_tmp1 = new Matrix2D();
        static Vect2D m_tmp2 = new Vect2D();
        const double GRAD_RAD = Math.PI / 180.0;
        const double RAD_GRAD = 180.0 / Math.PI;
        #endregion

        public void SetPosRotMat(double aAlphaGrad)
        {
            a11 = Math.Cos(aAlphaGrad); a12 = -Math.Sin(aAlphaGrad);
            a21 = Math.Sin(aAlphaGrad); a22 = Math.Cos(aAlphaGrad);
        }

        public void SetNegRotMat(double aAlphaGrad)
        {
            a11 = Math.Cos(aAlphaGrad); a12 = Math.Sin(aAlphaGrad);
            a21 = -Math.Sin(aAlphaGrad); a22 = Math.Cos(aAlphaGrad);
        }

        public void MakeRotMat(Vect2D aX)
        {
            m_tmp2 = aX.GetNormalizedVersion();
            a11 = m_tmp2.X; a12 = -m_tmp2.Y;
            a21 = m_tmp2.Y; a22 = m_tmp2.X;
        }

        public Matrix2D GetTransposed()
        {
            m_tmp1.a11 = a11; m_tmp1.a12 = a21;
            m_tmp1.a21 = a12; m_tmp1.a22 = a22;
            return m_tmp1;
        }

        public Vect2D Mult(Vect2D aY)
        {
            m_tmp2.X = a11 * aY.X + a12 * aY.Y;
            m_tmp2.Y = a21 * aY.X + a22 * aY.Y;
            return m_tmp2;
        }
    }

    public struct Line2D
    {
        public static Line2D ini;
        public Vect2D pt;
        public Vect2D dir;
        static Pen _pen = new Pen(Color.Red, 2);

        public void Init(Vect2D aA, Vect2D aB)
        {
            pt = aA;
            dir = aB - aA;
            dir = dir.GetNormalizedVersion();
        }

        // Midpoint between aA and aB is use as pt
        public void InitMid(Vect2D aA, Vect2D aB)
        {
            Vect2D v1 = aB - aA;
            v1 = v1.GetNormalizedVersion();
            v1 = v1.ScalarMult(aA.DistBetweenPoints(aB) / 2);
            pt = aA + v1;
            dir = v1.GetNormalizedVersion();
        }

        public Line2D GetNormalLine()
        {
            Line2D norm;
            norm.dir = dir.GetNormalVector();
            norm.pt = pt;
            return norm;
        }

        public void Init(double aX1, double aY1, double aX2, double aY2)
        {
            Vect2D a = Vect2D.Create(aX1, aY1, false);
            Vect2D b = Vect2D.Create(aX2, aY2, false);
            pt = a;
            dir = b - a;
            dir = dir.GetNormalizedVersion();
        }

        // pt is used as Midpoint, aLen from pt in both directions
        public void Paint1(Graphics gr, double aLen)
        {
            Vect2D e1 = pt + dir.ScalarMult(aLen);
            Vect2D e2 = pt - dir.ScalarMult(aLen);
            _pen.Color = Color.Red;
            gr.DrawLine(_pen, pt.AsPoint, e1.AsPoint);
            // _pen.Color = Color.Aquamarine;
            gr.DrawLine(_pen, pt.AsPoint, e2.AsPoint);
        }
    }
}
