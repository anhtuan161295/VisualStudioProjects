using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = "Hello World";
            int n = 5;
            bool test = false;
            Console.WriteLine(s + "\nI am " + n);
            Console.WriteLine("{0} \nI am {1}", s, "HAHAHA");

            if (test)
            {
                Console.WriteLine("{0} \nI am {1}", s, "PRO");
            }
            else
            {
                Console.WriteLine("{0} \nI am {1}", s, "NOOB");
            }
        }
    }
}
