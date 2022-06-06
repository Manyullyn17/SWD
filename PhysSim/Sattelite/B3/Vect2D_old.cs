

using System;
using System.Globalization;
using System.Drawing;


namespace MV
{
	///<summary>2 Dim Vektor und Operationen (Radius, Phi, Add..) für
	///2 Dim Vektor</summary>
	public struct Vect2D
	{
		#region Member Variablen
		private double m_X, m_Y;	// genaue Koordinaten
		private static Point m_P; // Hilfsvariable
		const double GRAD_RAD = Math.PI/180.0;
		const double RAD_GRAD = 180.0/Math.PI;
    static Vect2D m_tmp = new Vect2D();
    #endregion

		///<summary>X Koordinate in double</summary>
		public double X
		{
			get{ return m_X; }
			set{ m_X=value; }
		}
		
		///<summary>Y Koordinate in double</summary>
		public double Y
		{
			get{ return m_Y; }
			set{ m_Y=value; }
		}

		///<summary>X Koordinate in int</summary>
		public int XI
		{
			get{ return (int)m_X; }
		}
		///<summary>Y Koordinate in int</summary>
		public int YI
		{
			get{ return (int)m_Y; }
		}

		public Point AsPoint
		{
			get{ m_P.X=(int)m_X; m_P.Y=(int)m_Y; return m_P; }
			set
			{
				m_X=value.X; m_Y=value.Y;
			}
		}

		public override string ToString()
		{ return String.Format("{0};{1}", XI, YI); }

    public void PrintRPhi()
    {
      Console.WriteLine("{0:F1}  {1:F1}", GetR(), GetPhiGrad());
    }
    
    public void PrintXY()
    {
      Console.WriteLine("{0:F1}  {1:F1}", X, Y);
    }

		public void SetXY(double aX, double aY)
		{ m_X=aX; m_Y=aY; }

		public void SetXY(int aX, int aY)
		{ m_X=aX; m_Y=aY; }

		///<summary>Über Polarkoordinate R, Phi setzen</summary>
		public void SetFrom_R_Phi(double aR, double aPhi)
		{
			m_X = aR*Math.Cos(GRAD_RAD*aPhi);
			m_Y = aR*Math.Sin(GRAD_RAD*aPhi);
		}

		public double GetPhi()
		{
			if( m_X==0.0 && m_Y==0.0 )
				return 0.0;
			
			if( m_X==0.0 )
			{
				if( m_Y>0.0 )
					return Math.PI/2;
				else
					return -Math.PI/2;
			}
			
			if( m_Y==0.0 )
			{
				if( m_X>0.0 )
					return 0;
				else
					return -Math.PI;
			}
			
			double phi = Math.Abs(Math.Atan(m_Y/m_X));

			if( m_X>0.0 )
			{
				if( m_Y>0 )
					return Math.Abs(phi);
				else // m_Y<0.0
					return -Math.Abs(phi);
			}
			else // m_X<0.0
			{
				if( m_Y>0 )
					return Math.PI - Math.Abs(phi);
				else // m_Y<0.0
					return -(Math.PI - Math.Abs(phi));
			}
		}

		public double GetPhiGrad() { return RAD_GRAD*GetPhi(); }

		public double GetR()
		{
			return Math.Sqrt(m_X*m_X + m_Y*m_Y);
		}

		public void Add_R(double aR)
		{
			double r = Math.Sqrt(m_X*m_X + m_Y*m_Y);
			r += aR;  double phi=GetPhi();
			m_X = r*Math.Cos(phi); m_Y = r*Math.Sin(phi);
    }
    
    public void Add_Phi(double aPhi)
    {
      m_tmp.m_X = Math.Cos(aPhi);
      m_tmp.m_Y = Math.Sin(aPhi);
      CoMult(m_tmp);
    }

    public void Add_PhiGrad(double aPhi)
    {
      this.Add_Phi(GRAD_RAD * aPhi);
    }
    
    public void Assign(Vect2D aVect)
		{ m_X=aVect.m_X; m_Y=aVect.m_Y; }
		
		public void AddTo(Vect2D aVect)
		{
			m_X = m_X + aVect.m_X;
			m_Y = m_Y + aVect.m_Y;
		}
		
		public void SubFrom(Vect2D aVect)
		{
			m_X = m_X - aVect.m_X;
			m_Y = m_Y - aVect.m_Y;
		}

    // Vector from aP1 to aP2
    public static Vect2D VectBetweenPoints(Vect2D aP1, Vect2D aP2)
    {
      m_tmp.X = aP2.X - aP1.X;
      m_tmp.Y = aP2.Y - aP1.Y;
      return m_tmp;
    }

    public void CoMult(Vect2D aB)
    {
      double Xres, Yres;
      Xres = m_X * aB.m_X - m_Y * aB.m_Y;
      Yres = m_X * aB.m_Y + m_Y * aB.m_X;
      m_X = Xres; m_Y = Yres;
    }

    public Vect2D ScalarMult(double aFactor)
    {
      m_tmp.X = m_X * aFactor;
      m_tmp.Y = m_Y * aFactor;
      return m_tmp;
    }

		///<summary>Vektorlänge sqrt(x*x + y*y)</summary>
		public double VectLength()
		{ return Math.Sqrt(m_X*m_X + m_Y*m_Y); }

    public double DistBetweenPoints(Vect2D aB)
    {
      double xd = m_X - aB.m_X;
      double yd = m_Y - aB.m_Y;
      return Math.Sqrt(xd*xd + yd*yd);
    }
    
    public bool IsZero()
    {
      return m_X == 0.0 && m_Y == 0.0;
    }
  }

}


















