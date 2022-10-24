using MV;
using System;
using System.Drawing;
using System.Drawing.Text;

namespace Collide
{
    public class Ball
    {
        public Vect2D pos, V;
        public int m;
        public int num;
        static Pen _pen = new Pen(Color.DarkMagenta, 2);
        static SolidBrush _brush = new SolidBrush(Color.Black);
        static Font _font = new Font("Arial", 24, FontStyle.Bold, GraphicsUnit.Pixel);
        static StringFormat _format = new StringFormat(StringFormatFlags.NoClip);

        public Ball()
        {
        }

        public Ball(int aX, int aY, int aNum)
        {
            pos.SetXY(aX, aY);
            num = aNum;
        }

        public Ball(Point aP, int aNum)
        {
            pos.AsPoint = aP;
            num = aNum;
        }

        // Xn+1 = Xn + V*dt
        public void CalcNextPos()
        {
            if (V.VectLength() > 0.1)
                V = V.ScalarMult(Par.KR_CALC);
            else
                V = V.ScalarMult(Par.KR_CALC/100);
            pos.AddTo(V, Par.DT);
        }

        public double Distance(Ball aB2)
        {
            return pos.DistBetweenPoints(aB2.pos);
        }

        public void Paint(Graphics gr, int i)
        {
            _format.Alignment = StringAlignment.Center;
            _format.LineAlignment = StringAlignment.Center;
            int xo = Par.BALL_DIAM / 2;
            int w = Par.BALL_DIAM;
            Rectangle rect = new Rectangle(pos.XI - xo, pos.YI - xo, w, w);
            if (i == 0)
                _pen.Color = Color.Red;
            else
                _pen.Color = Color.Green;
            gr.DrawEllipse(_pen, pos.XI - xo, pos.YI - xo, w, w);
            gr.DrawString(num.ToString(), _font, _brush, rect, _format);
            PaintV1(gr, pos);
        }

        public void PaintV1(Graphics gr, Vect2D pt)
        {
            if (V.IsZero())
                return;
            // _pen.EndCap = LineCap.ArrowAnchor;
            Vect2D pt2 = pt + V * 15;
            _pen.Color = Color.DarkMagenta;
            gr.DrawLine(_pen, pt2.AsPoint, pt.AsPoint);
        }

        public bool ReflectInWindow(Size aSz)
        {
            if ((pos.X < -aSz.Width/2) && (V.X < 0))
            { V.X = -V.X; return true; }

            if ((pos.X > aSz.Width/2) && (V.X > 0))
            { V.X = -V.X; return true; }

            if ((pos.Y < -aSz.Height/2) && (V.Y < 0)) // Par.BALL_DIAM / 2) && (V.Y < 0))
            { V.Y = -V.Y; return true; }

            if ((pos.Y > aSz.Height/2) && (V.Y > 0))
            { V.Y = -V.Y; return true; }

            return false;
        }

        public virtual void WasReflected()
        {
        }
    }


    public class Collider
    {
        public static void ReflectY(Ball aB)
        {
            if (aB.V.IsZero())
                return;
            if ((aB.pos.X > 0) && (aB.V.X < 0))
            {
                aB.V.X = -aB.V.X;
                return;
            }
            if ((aB.pos.X < 0) && (aB.V.X > 0))
            {
                aB.V.X = -aB.V.X;
                return;
            }
        }

        public static void Reflect(Ball aB1, Ball aB2)
        {
            Vect2D r1 = Vect2D.VectBetweenPoints(aB2.pos, aB1.pos);
            r1 = r1.GetNormalizedVersion();
            Vect2D r2 = r1.GetComplexConjugate();
            aB1.V.CoMultTo(r2); ReflectY(aB1); aB1.V.CoMultTo(r1);
            aB2.V.CoMultTo(r2); ReflectY(aB2); aB2.V.CoMultTo(r1);
        }

        public static void Collide1(Ball aB1, Ball aB2)
        {
            // Vektor von B1 nach B2
            Vect2D r1 = Vect2D.VectBetweenPoints(aB2.pos, aB1.pos);

            // vektor zum Zurückdrehen
            r1 = r1.GetNormalizedVersion(); // auf die Länge 1

            // vektor zum Vorwärtsdrehen
            Vect2D r2 = r1.GetComplexConjugate();

            // V-Vektoren so drehen, daß die Stoßnormale mit der Y-Achse zusammenfällt
            aB1.V.CoMultTo(r2); aB2.V.CoMultTo(r2);

            // Vx-Komponenten austauschen Vy-Komponenten bleiben unverändert
            ImpulseRule2(aB1, aB2);

            // V-Vektoren wieder zurückdrehen
            aB1.V.CoMultTo(r1); aB2.V.CoMultTo(r1);
        }

        // Mass is !!not!! used
        static void ImpulseRule1(Ball aB1, Ball aB2)
        {
            double tmp = aB1.V.X;
            aB1.V.X = aB2.V.X;
            aB2.V.X = tmp;
        }

        // Mass is used
        static void ImpulseRule2(Ball b1, Ball b2)
        {
            int nenner = b1.m + b2.m;
            double v1s, v2s;
            v1s = ((b1.m - b2.m) * b1.V.X + 2 * b2.m * b2.V.X) / (double)nenner;
            v2s = ((b2.m - b1.m) * b2.V.X + 2 * b1.m * b1.V.X) / (double)nenner;
            b1.V.X = v1s;
            b2.V.X = v2s;
        }
    }


    public class BallMgr
    {
        public Ball[] b = new Ball[11];
        bool didCollide;
        public Size WndSize;

        public void ClearList()
        {
            for (int i = 0; i < 11; i++)
                b[i] = null;
        }

        public void ReverseSpeed()
        {
            for (int i = 0; i < 11; i++)
                b[i].V = b[i].V.GetOppositeDirection();
        }

        public void CalcNextPositions()
        {
            for (int i = 0; i < 11; i++)
                if (b[i] == null)
                    return;

            for (int i = 1; i < Par.ITER_PER_TICK; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (b[j].ReflectInWindow(WndSize))
                        b[j].WasReflected();
                    b[j].CalcNextPos();
                }

                for (int j = 0; j < 10; j++)
                {
                    for (int i2 = j + 1; i2 < 11; i2++)
                    {
                        if (didCollide && (b[j].Distance(b[i2]) < Par.BALL_DIAM + 5))
                            continue;
                        else
                            didCollide = false;
                    }
                }

                for (int j = 0; j < 10; j++)
                {
                    for (int i2 = j + 1; i2 < 11; i2++)
                    {
                        if (b[j].Distance(b[i2]) < Par.BALL_DIAM)
                        {
                            Collider.Collide1(b[j], b[i2]);
                            didCollide = true;
                        }
                    }
                }
            }
        }

        public void Paint(Graphics gr)
        {
            for (int i = 0; i < 11; i++)
                if (b[i] != null)
                {
                    b[i].Paint(gr, i);
                }
        }
    }
}
