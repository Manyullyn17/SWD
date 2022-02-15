using System;
using System.Text;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex a = new Complex(1, 2);  // a = 1 + j*2
            Complex b = new Complex(3, -4);      // b = 3 - j*4

            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
        }
    }
}
