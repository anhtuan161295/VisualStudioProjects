/*
    * Static methods that do not operate on objects
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session05_OOP
{
    class Ex02_StaticsMethod
    {
        static void methodStatic()
        {
            Console.WriteLine("Static method");
        }

        void methodNonStatic()
        {
            Console.WriteLine("Non Static method");
        }

       static void Main(string[] args)
        {
            //Call Static method
            Ex02_StaticsMethod.methodStatic();
            
            //Call Non Static method
            Ex02_StaticsMethod test = new Ex02_StaticsMethod();
            test.methodNonStatic();
            Console.ReadKey();
        }
    }
}
