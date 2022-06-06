
using System;

// V1.1
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
      a11 = m_tmp2.X;  a12 = -m_tmp2.Y;
      a21 = m_tmp2.Y;  a22 = m_tmp2.X;
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
    bool isInitialized;
    public Vect2D A;
    public Vect2D B;
    static Vect2D m_tmp = new Vect2D();
    static Line2D sL1 = new Line2D();

    public void Init()
    {
      if (!isInitialized)
      {
        A = new Vect2D();
        B = new Vect2D();
        isInitialized = true;
      }
    }

    public void Init(Vect2D aA, Vect2D aB)
    {
      this.Init();
      A = aA; B = aB;
    }

    public void Init(double aX1, double aY1, double aX2, double aY2)
    {
      Init();
      A.X = aX1; A.Y = aY1;
      B.X = aX2; B.Y = aY2;
    }

    public override string ToString()
    {
      return String.Format("A={0}  B={1}", A, B);
    }

    public Vect2D Direction()
    {
      m_tmp.X = B.X - A.X;
      m_tmp.Y = B.Y - A.Y;
      return m_tmp;
    }

    public Vect2D MidPoint()
    {
      m_tmp = Vect2D.VectBetweenPoints(A, B);
      m_tmp = m_tmp.GetScaledVersion(m_tmp.VectLength() / 2);
      m_tmp = A.Add(m_tmp);
      return m_tmp;
    }

    public static Line2D CreateLine(Vect2D aMidPoint, Vect2D aDirection, double aLength)
    {
      sL1.Init();
      aDirection = aDirection.GetScaledVersion(aLength / 2);
      sL1.A = aMidPoint.Add(aDirection);
      sL1.B = aMidPoint.Add(aDirection.GetOppositeDirection());
      return sL1;
    }
  }
}
