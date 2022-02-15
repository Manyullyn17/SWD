using System;
using System.Text;

namespace MTime
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklaration 2er Referenzen auf MTime Objekte
            MTime t1, t2;

            // Ein MTime Objekt 00:00:00 erzeugen
            t1 = new MTime("t1");

            // Ein MTime Objekt 01:27:42 erzeugen
            t2 = new MTime("t2", 1, 27, 42);

            t1.Print(); t2.Print();

            t2.AddSeconds(90);
            t1.AddMinutes(70);

            t1.Print();  t2.Print();

            t1.SetMinutes(50);

            t1.Minutes = 70; t1.Print();
            t1.Minutes = 45; t1.Print();

            Console.WriteLine(t1.Minutes);
        }
    }
}
