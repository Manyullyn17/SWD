
using System;
using System.Collections;
using System.Text;

namespace LL_CS
{
  class Program
  {
    CsLinkedList _ll = new CsLinkedList();
    
    static void Main(string[] args)
    {
      Program pg = new Program();
      pg.Test1();
    }

    void Test1()
    {
      _ll.AddHead(10); _ll.AddHead(20); _ll.AddHead(30);
      _ll.AddHead(40); _ll.AddHead(50); _ll.AddHead(60);
      _ll.Print();

      _ll.RemoveHead(); _ll.Print();
      _ll.RemoveHead(); _ll.Print();
      _ll.RemoveHead(); _ll.Print();
      _ll.RemoveHead(); _ll.Print();
      _ll.RemoveHead(); _ll.Print();
      _ll.RemoveHead(); _ll.Print();
      _ll.RemoveHead(); _ll.Print();
    }

    void Test2()
    {
      // Das Ganze ( siehe Test1 ) für AddTail()/RemoveTail
      _ll.AddTail("aaa"); _ll.AddTail("bbb"); _ll.AddTail("ccc");
    }

    // Find() testen
    void Test3()
    {
      for (int i = 10; i <= 200; i += 10)
        _ll.AddTail(i);
      _ll.Print();

      IComparer cmp = new IntCompare();
      object elem = _ll.Find(12, cmp);
      if (elem != null)
        Console.WriteLine("12 not found");
      else
        Console.WriteLine("12 found");
    }

    // Find() für Students
    void Test4()
    {
      _ll.AddTail(new Student("Franz", 10));
      _ll.AddTail(new Student("Hugo", 13));
      _ll.AddTail(new Student("Sepp", 27));
      _ll.AddTail(new Student("Sebi", 45));
      _ll.AddTail(new Student("Gerti", 23));

      StudentNameCompare cmp = new StudentNameCompare();

      // object elem1 = _ll.Find(new Student("Sepp", 0), cmp);
      CheckObj(new Student("Sepp", 0), cmp);

      // Auch noch nach Student.m_CatNr suchen
      // mit einem StudentCatNrCompare
    }

    void CheckObj(Object aTestObject, IComparer aCmp)
    {
      object elem = _ll.Find(aTestObject, aCmp);
      if (elem != null)
        Console.WriteLine("{0} found", elem);
      else
        Console.WriteLine("{0} !!NOT!! found", aTestObject);
    }
  }
}
