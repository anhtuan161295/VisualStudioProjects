using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session02_Statement_Operators
{
    class Ex01_DataConversions
    {
        static void Main(string[] args)
        {
            //Implicit conversions
            int int_Implicit = 1000;
            long long_Implicit = int_Implicit;
            Console.WriteLine("Implicit (int -> long): long_Implicit = {0}", long_Implicit);

            //Explicit conversions
            long long_Explicit = Int16.MaxValue;
            int int_Explicit = (int)long_Explicit;
            Console.WriteLine("Explicit (long -> int): int_Explicit = {0}", int_Explicit);
            Console.ReadKey();
        }
    }
}
