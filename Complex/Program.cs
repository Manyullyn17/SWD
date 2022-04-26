using System;
using System.Text;


namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            Test2();
        }

        static void Test1()
        {
            Complex a = new Complex(1, 2); // a = 1 + j*2;
            Complex b = new Complex(3, -4); // b = 3 - j*4;
            Complex c = Complex.Create(0, 0);

            // Add als Member-Funktion
            c = a.Add(b);   // c = a + b
            // Add als statische Funktion
            c = Complex.Add(a, b);

            // mit operator overloading
            c = a + b + Complex.Create(9, -10);

            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.WriteLine("c = {0}", c);
        }

        static void Test2()
        {
            Complex a = Complex.Create(2, 10, true);    // a = 2\10°
            Complex b = Complex.Create(3, 30, true);    // b = 3\30°
            Complex c;
            
            c = a * b;

            // a, b, c in Polar ausgeben
            Console.WriteLine("a_Polar = {0}", a.AsPolar());
            Console.WriteLine("b_Polar = {0}", b.AsPolar());
            Console.WriteLine("c_Polar = {0}", c.AsPolar());
        }
    }
}
