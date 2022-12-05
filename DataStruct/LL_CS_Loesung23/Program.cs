using System;

namespace LL_CS
{
    class Program
    {
        CsLinkedList _ll = new CsLinkedList();

        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.Test5();
        }

        void Test1()
        {
            // _ll.AddHead("aaa"); _ll.AddHead("bbb"); _ll.AddHead("ccc");
            for (int i = 1; i < 10; i++)
                _ll.AddHead(i);
            _ll.Print();

            // RemoveHead implemetieren und testen
            for (int i = 0; i < 12; i++)
            {
                _ll.RemoveHead(); _ll.Print();
            }
        }

        void Test2()
        {
            //_ll.AddTail("i"); _ll.AddTail("love"); _ll.AddTail("niggers");
            for (int i = 0; i < 10; i++)
                _ll.AddTail(i);
            _ll.Print();

            for (int i = 0; i < 12; i++)
            {
                _ll.RemoveTail(); _ll.Print();
            }
        }

        void Test3()
        {
            _ll.AddTail(new Student("aaa", 20));
            _ll.AddTail(new Student("bbb", 30));
            _ll.AddTail(new Student("ccc", 40));
            _ll.AddTail(new Student("ddd", 50));

            Student missing = new Student("ccc", 0);
            StudentNameCompare cmp = new StudentNameCompare();

            Student found = (Student)_ll.Find(missing, cmp);
            if (found == null)
                Console.WriteLine("Not Found");
            else
                Console.WriteLine("Found {0}", found);
        }

        void Test4()
        {
            _ll.AddTail(new Student("aaa", 20));
            _ll.AddTail(new Student("bbb", 30));
            _ll.AddTail(new Student("ccc", 40));
            _ll.AddTail(new Student("ddd", 50));

            Student missing = new Student("xxx", 0);
            StudentNameCompare cmp = new StudentNameCompare();

            _ll.Print();
            missing.m_Name = "aaa";
            _ll.Remove(_ll.Find(missing, cmp)); _ll.Print();
            missing.m_Name = "ddd";
            _ll.Remove(_ll.Find(missing, cmp)); _ll.Print();
        }

        void Test5()
        {
            // InsertSorted testen

            StudentCatNrCompare cmp = new StudentCatNrCompare();

            _ll.InsertSorted(new Student("aaa", 40), cmp);
            _ll.InsertSorted(new Student("bbb", 30), cmp);
            _ll.InsertSorted(new Student("ccc", 50), cmp);
            _ll.InsertSorted(new Student("ddd", 20), cmp);

            _ll.Print();
            // Liste soll nach CatNr sortiert sein
        }
    }
}
