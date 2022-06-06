
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MV;

namespace Collide
{
  public class Ball
  {
    public Vect2D pos, V;
    public int m;
    static Pen _pen = new Pen(Color.DarkMagenta, 2);

    public Ball()
    {
    }

    public Ball(int aX, int aY)
    {
      pos.SetXY(aX, aY);
    }

    public Ball(Point aP)
    {
      pos.AsPoint = aP;
    }

    // Xn+1 = Xn + V*dt
    public void CalcNextPos()
    {
      pos.AddTo(V, Par.DT);
    }

    public double Distance(Ball aB2)
    {
      return pos.DistBetweenPoints(aB2.pos);
    }
 
    public void Paint(Graphics gr)
    {
      int xo = Par.BALL_DIAM / 2;
      int w = Par.BALL_DIAM;
      _pen.Color = Color.Green;
      gr.DrawEllipse(_pen, pos.XI - xo, pos.YI - xo, w, w);
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
    public Ball b1, b2;
    bool didCollide;

    public void ClearList()
    {
      b1 = b2 = null;
    }

    public void ReverseSpeed()
    {
      b1.V = b1.V.GetOppositeDirection();
      b2.V = b2.V.GetOppositeDirection();
    }
    
    public void CalcNextPositions()
    {
      if (b1 == null || b2 == null)
        return;
      for (int i = 1; i < Par.ITER_PER_TICK; i++)
      {
        b1.CalcNextPos();
        b2.CalcNextPos();

        if (didCollide && (b1.Distance(b2) < Par.BALL_DIAM + 5))
          continue;
        else
          didCollide = false;
        
        if (b1.Distance(b2) < Par.BALL_DIAM)
        {
          Collider.Collide1(b1, b2);
          didCollide = true;
        }
      }
    }
    
    public void Paint(Graphics gr)
    {
      if( b1!=null )
        b1.Paint(gr);
      if( b2!=null )
        b2.Paint(gr);
    }
  }
}
