using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MV;

namespace satellite
{

	public class GraphicObject
	{
		#region Member Variablen
		protected static SolidBrush foregBrush, backgBrush;
		protected static Pen foregPen;
		
		protected Color m_Color;

		protected Vect2D m_Pos;

		private static Vect2D m_Temp = new Vect2D();
		#endregion

		public Vect2D Pos
		{
			get{ return m_Pos; }
			set{ m_Pos=value; }
		}

		public void SetPos(Point aPoint)
		{ m_Pos.AsPoint = aPoint; }

		public void SetPos(int aX, int aY)
		{ m_Pos.X=aX; m_Pos.Y=aY; }

		public void SetColor(Color aColor)
		{ this.m_Color=aColor; }

		public static void SetDefaultColors(Color aBackgColor, Color aForegColor)
		{
			foregBrush = new SolidBrush(aForegColor);
			backgBrush = new SolidBrush(aBackgColor);
			foregPen = new Pen(aForegColor);
		}

		public GraphicObject()
			{ m_Pos.SetXY(0,0); }
		
		public GraphicObject(Point aPos, Color aCol)
			{ m_Pos.AsPoint=aPos; m_Color=aCol; }

		///<summary>Gibt die Ausdehnung des Grafikobjektes als Kreis für
		///z.B. Trefferberechnungen zurück</summary>
		public virtual double GetRadius()
		{ return 10.0; }

		///<summary>Gibt die Ausdehnung des Grafikobjektes als Rechteck für
		///z.B. Trefferberechnungen zurück</summary>
		public virtual Size GetSize()
		{ return new Size(20,20); }

		///<summary>Das Grafikobjekt zeichen</summary>
		public virtual void PaintVisible(Graphics g)
		{
			foregBrush.Color = m_Color;
			g.FillEllipse(foregBrush, m_Pos.XI, m_Pos.YI, 10,10);
		}
		
		///<summary>Das Grafikobjekt durch zeichen in der Hintergrundfarbe löschen</summary>
		public virtual void PaintInVisible(Graphics g)
		{ g.FillEllipse(backgBrush, m_Pos.XI, m_Pos.YI, 10,10); }

		///<summary>Liegt der Punkt aPos innerhalb der Radius-Ausdehnung des Grafikobjektes</summary>
		public bool HitRadius(Point aPos)
		{
			m_Temp.AsPoint = aPos;
			if (m_Temp.DistBetweenPoints(m_Pos) < GetRadius())
				return true;
			return false;
		}

		public double DistBetweenObjects(GraphicObject aB)
		{
			return m_Pos.DistBetweenPoints(aB.m_Pos);
		}

		public Vect2D VectBetweenObjects(GraphicObject aB)
		{
			return Vect2D.VectBetweenPoints(Pos, aB.Pos);
		}

		#region Old Code
		/* if( (aPos.X < m_Pos.X + (this.GetSize().Width/2)) && (aPos.X > m_Pos.X - (this.GetSize().Width/2)) &&
				(aPos.Y < m_Pos.Y + (this.GetSize().Height/2)) && (aPos.Y > m_Pos.Y - (this.GetSize().Height/2)) ) */
		#endregion
	}
}
