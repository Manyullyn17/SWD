using System;
using System.Text;

namespace Stack17
{
  class Program
  {
    static void Main(string[] args)
    {
      Test3();
    }

    static void Test1()
    {
      Stack st1 = new Stack(10);

      st1.Push(10); st1.Push(20); st1.Push(30);

      st1.Print();

      Console.WriteLine("{0} {1} {2}", st1.Pop(), st1.Pop(), st1.Pop());
    }

    static void Test2()
    {
      // overflow austesten
      Stack st1 = new Stack(3);
      try
      {
        st1.Push(100); st1.Push(200); st1.Push(300);
        st1.Push(400);
      }
      catch(StackException ex)
      {
        Console.WriteLine("Es wurden zuviele Werte gepushed");
      }
      st1.Print();
      
      // Test UnderFlow
      try
      {
        Console.WriteLine("{0} {1} {2}", st1.Pop(), st1.Pop(), st1.Pop());
        Console.WriteLine("{0}", st1.Pop());
      }
      catch (StackException ex)
      {
        Console.WriteLine("Es wurden zuviele Werte gelesen");
      }
      
    }

    static void Test3()
    {
      // Copy-Konstruktor testen
      Stack st1 = new Stack(10);
      st1.Push(17); st1.Push(18); st1.Push(19);

      // st2 als Kopie von st1
      Stack st2 = new Stack(st1);

      st1.Print();
      st2.Print();

      // st2.tmp;
    }
  }
}
