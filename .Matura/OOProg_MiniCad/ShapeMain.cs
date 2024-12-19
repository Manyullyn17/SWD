using System;
using System.Collections;
using System.Text;


namespace Shape
{
  class Program
  {
    static ArrayList _list = new ArrayList();

    static void Main(string[] args)
    {
      // Test1();
      FillObjects();
      DrawObjects();
    }

    static void FillObjects()
    {
      _list.Add(new Shape(new Point(2, 3)));
      _list.Add(new Rectangle(new Point(10, 10), new Point(20, 20)));
      _list.Add(new Circle(new Point(15, 15), 20));
      _list.Add("Hallo");
      _list.Add(new Rectangle(new Point(30, 30), new Point(40, 40)));
    }

    static void DrawObjects()
    {
      Shape sh;
      for(int i=0; i<_list.Count; i++)
      {
        try
        {
          sh = (Shape)_list[i];
          sh.Draw();
        }
        catch(Exception ex)
        {
          Console.WriteLine("Kein Shape");
        }
      }
    }

    static void Test1()
    {
      Shape sh = new Shape(new Point(2, 3));
      Rectangle rc = new Rectangle(new Point(10, 10), new Point(20, 20));
      Circle cr = new Circle(new Point(15, 15), 20);

      sh.Draw();
      rc.Draw();
      cr.Draw();
      rc.Move(10, 10);
      rc.Draw();
    }
  }
}
