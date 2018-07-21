/*
 * Boxing : converts a value type to the type object or to any interface type implemented by this value type.
 * Unboxing : extracts the value type from the object. 
 * Boxing is implicit but Unboxing is explicit.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session02_Statement_Operators
{
    class Ex02_Boxing_Unboxing
    {
        static void Main(string[] args)
        {
            //Boxing
            int i = 100;
            object boxing = i;

            System.Console.WriteLine("The boxing value = {0}", boxing);

            // Unboxing
            int unBoxing = (int)boxing;

            System.Console.WriteLine("The unBoxing value = {0}", unBoxing);
            Console.ReadKey();
        }
    }
}
