using System;
using System.Drawing;


namespace Andlar
{

    public class GraphicObject
    {
        #region Member Variablen
        protected Point m_Pos;
        protected Color m_Color;
        // Hilfsvariablen
        protected static SolidBrush foregBrush, backgBrush;
        #endregion

        public GraphicObject() { }

        public GraphicObject(int aX, int aY, Color aCol)
        {
            m_Pos.X = aX; m_Pos.Y = aY; m_Color = aCol;
        }

        public static void SetDefaultColors(Color aBackgColor, Color aForegColor)
        {
            foregBrush = new SolidBrush(aForegColor);
            backgBrush = new SolidBrush(aBackgColor);
        }

        public void SetPos(Point aPoint)
        { m_Pos = aPoint; }

        public void SetPos(int aX, int aY)
        { m_Pos.X = aX; m_Pos.Y = aY; }

        public Point GetPos()
        { return m_Pos; }

        public void SetColor(Color aColor)
        { m_Color = aColor; }

        ///<summary>Das Grafikobjekt zeichen</summary>
        public virtual void PaintVisible(Graphics g)
        { }

        ///<summary>Das Grafikobjekt durch zeichen in der Hintergrundfarbe l�schen</summary>
        public virtual void PaintInVisible(Graphics g)
        { }

        public virtual int GetRadius()
        { return 1; }

        public bool HitInRadius(Point aP)
        {
            // Wenn Vektor zw. Mausz. (aP) und m_Pos
            // kleiner als Radius des Objektes ist => getroffen
            // ansonsten nicht getroffen
            int rvx = aP.X - m_Pos.X;
            int rvy = aP.Y - m_Pos.Y;
            int rvlen = (int)Math.Sqrt(rvx * rvx + rvy * rvy);

            if (rvlen < GetRadius())    // getroffen
                return true;

            return false;
        }
    }
}
