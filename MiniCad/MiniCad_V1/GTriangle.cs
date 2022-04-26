using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andlar
{
    public class GTriangle : GraphicObject
    {
		// Array aus Punkten für die Seiten des Dreiecks
		// Die aktuellen Koordinaten werden in Paint abhängig vom momentanen m_Pos gesetzt
		private static Point[] m_Points = { new Point(0), new Point(0), new Point(0) };

		public GTriangle() : base() { }

		public GTriangle(int aX, int aY, Color aCol) : base(aX, aY, aCol) { }

		public override void PaintVisible(Graphics g)
		{
			foregBrush.Color = m_Color;
			m_Points[0].X = m_Pos.X - 15;	m_Points[0].Y = m_Pos.Y + 15;
			m_Points[1].X = m_Pos.X + 15;	m_Points[1].Y = m_Pos.Y + 15;
			m_Points[2].X = m_Pos.X;		m_Points[2].Y = m_Pos.Y - 15;
			g.FillPolygon(foregBrush, m_Points);
		}

		public override void PaintInVisible(Graphics g)
        {
			m_Points[0].X = m_Pos.X - 15; m_Points[0].Y = m_Pos.Y + 15;
			m_Points[1].X = m_Pos.X + 15; m_Points[1].Y = m_Pos.Y + 15;
			m_Points[2].X = m_Pos.X; m_Points[2].Y = m_Pos.Y - 15;
			g.FillPolygon(backgBrush, m_Points);
		}

		public override int GetRadius()
        {
			return 15;
        }
	}
}
