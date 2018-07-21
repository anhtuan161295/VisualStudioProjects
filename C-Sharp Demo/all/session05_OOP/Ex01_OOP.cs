/*
 * An abstract class cannot be instantiated.
 * An abstract class may contain abstract methods and accessors.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session05_OOP
{
    class A
    {
        public A()
        {
            Console.WriteLine("Using A class method");
        }
        public int add(int x, int y)
        {
            return x + y;
        }

    }

    class Ex01_OOP
    {
        static void Main(string[] args)
        {
            A obj = new A();
            int a = 10, b = 20;

            Console.WriteLine("{0} + {1} = {2}", a, b, obj.add(a, b));
            Console.ReadKey();
        }
    }
}
