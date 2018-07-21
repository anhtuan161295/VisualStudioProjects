/*
 * bool keyword is an alias of System.Boolean.
 * string is an alias for System.String.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session01_Variable_DataType
{
    class Ex03_OutputFormat
    {
        static void Main(string[] args)
        {
            int a = Int16.MaxValue;
            string s = "A";
            bool flag;

            //General Format 
            Console.WriteLine("One argument: {0}", "Hello");
            Console.WriteLine("Three arguments: {0}{1}{2}", "Hello", " ", "world");
            Console.WriteLine("Pass argument like java. value of string s: '" 
                              + s + "', int a: " + a);

            //Currency Format
            Console.WriteLine("Currency: {0:C}", 10);
            Console.WriteLine("Max value: {0}", a);

            //String compare
            flag = s.ToUpper().Equals("A");
            if (flag)
            {
                Console.WriteLine("OK");
            }
            Console.ReadKey();
        }
    }
}
