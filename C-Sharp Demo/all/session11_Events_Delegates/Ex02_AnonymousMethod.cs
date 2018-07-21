/*
 * Inline block of code that can be passed as a delegate parameter
 * Cover session 14 "Anonymous MethodsPartial and Nullable Types".
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session11_Events_Delegates
{
    delegate void Display(string s);
    
    class Ex02_AnonymousMethod
    {
        static void Main(string[] args)
        {
            //Anonymous method.
            Display display = delegate(string s)
            {
                Console.WriteLine(s);
            };

            //Anonymous delegate call.
            display("Anonymous method is called...");

            Console.ReadKey();
        }
    }
}
