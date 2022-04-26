using System;
using System.Text;

namespace Shape
{
    class Point
    {
        public int x, y;
        
        public Point(int aX, int aY)
        {
            x = aX; y = aY;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", x, y);
        }
    }


    class Shape
    {
        protected Point _P;

        public Shape(Point aP)
        {
            _P = aP;
        }

        public virtual void Move(int aDx, int aDy)
        {
            _P.x += aDx;
            _P.y += aDy;
        }

        public virtual void Draw()
        {
            Console.WriteLine("Shape: {0}", _P);
        }
    }


    class Rectangle : Shape
    {
        Point _P2;

        public Rectangle(Point aP1, Point aP2) : 
            base(aP1) // Konstruktor der Basisklasse aufrufen
        {
            _P2 = aP2;
        }

        public override void Move(int aDx, int aDy)
        {
            // Der Teil des Move, den die Basisklasse schon erledigt
            base.Move(aDx, aDy);
            // um _P2 muss sich Rectangle selber kümmern
            _P2.x += aDx;
            _P2.y += aDy;
        }

        public override void Draw()
        {
            Console.WriteLine("Rect: {0} {1}", _P, _P2);
        }
    }


    class Circle : Shape
    {
        int _R;
        
        public Circle(Point aP, int aR) :
            base(aP)
        {
            _R = aR;
        }

        // Shape.Move passt für Circle => muss nicht überschrieben werden

        public override void Draw()
        {
            Console.WriteLine("Circle: {0} {1}", _P, _R);
        }
    }
}
