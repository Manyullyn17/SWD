
using System;
using System.Collections;
using System.Text;

namespace LL_CS
{
    class Program
    {
        IHLContainer _ll = new CsArrayList();   //CsLinkedList();

        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.Test8();
        }

        void Test1()
        {
            _ll.AddHead("aaa"); _ll.AddHead("bbb"); _ll.AddHead("ccc");
            // for (int i = 1; i <= 5; i++)
            // _ll.AddHead(i);
            _ll.Print();

            // RemoveHead implemetieren und testen
            _ll.RemoveHead(); _ll.Print();
            _ll.RemoveHead(); _ll.Print();
            _ll.RemoveHead(); _ll.Print();
            _ll.RemoveHead(); _ll.Print();
        }

        void Test2()
        {
            _ll.AddTail("i"); _ll.AddTail("hate"); _ll.AddTail("niggers");
            _ll.Print();
            Console.WriteLine(_ll.RemoveTail());
            _ll.Print();
        }

        void Test3()
        {
            _ll.AddTail(new Student("aaa", 20));
            _ll.AddTail(new Student("bbb", 30));
            _ll.AddTail(new Student("ccc", 40));
            _ll.AddTail(new Student("ddd", 50));

            Student toFind = new Student("bbb", 0);
            StudentNameCompare cmp = new StudentNameCompare();
            Student ret = (Student)_ll.Find(toFind, cmp);

            if (ret == null)
            {
                Console.WriteLine("Not found!");
            }
            else Console.WriteLine("Found {0}", ret);
        }

        void Test4()
        {
            _ll.AddTail(new Student("aaa", 20));
            _ll.AddTail(new Student("bbb", 30));
            _ll.AddTail(new Student("ccc", 40));
            _ll.AddTail(new Student("ddd", 50));

            Student toFind = new Student("xxx", 0);
            StudentNameCompare cmp = new StudentNameCompare();

            toFind.m_Name = "ccc";
            Console.WriteLine(_ll.Remove(_ll.Find(toFind, cmp))); _ll.Print();

            toFind.m_Name = "ddd";
            Console.WriteLine(_ll.Remove(_ll.Find(toFind, cmp))); _ll.Print();
        }

        void Test5()
        {
            StudentCatNrCompare cmp = new StudentCatNrCompare();
            _ll.InsertSorted(new Student("ddd", 20), cmp);
            _ll.InsertSorted(new Student("aaa", 70), cmp);
            _ll.InsertSorted(new Student("aaa", 70), cmp);
            _ll.InsertSorted(new Student("bbb", 30), cmp);
            _ll.InsertSorted(new Student("ccc", 50), cmp);
            _ll.InsertSorted(new Student("ddd", 20), cmp);

            _ll.Print(); // Liste müsste nach Kat-Nr. sortiert sein.
        }

        void Test6()
        {
            for(int i = 1; i <= 20; i++)
            {
                _ll.AddTail(i);
            }
            _ll.Print();
        }

        void Test7()
        {
            for (int i = 1; i <= 20; i++)
            {
                _ll.AddTail(i);
            }
            _ll.Print();

            _ll.InsertAtPos(111, 15);
            _ll.Print();
            _ll.RemoveAt(20);
            _ll.Print();
        }

        // IEnum testen
        void Test8()
        {
            CsLinkedList2 list = new CsLinkedList2();

            for (int i = 1; i <= 5; i++)
                list.AddTail(i);

            foreach (int x in list)
            {
                Console.Write("{0} ", x);
            }
        }
    }
}