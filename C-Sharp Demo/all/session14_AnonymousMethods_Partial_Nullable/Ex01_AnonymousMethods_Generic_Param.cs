using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session14_AnonymousMethods_Partial_Nullable
{
    delegate T GenericType<T>(T type);

    class Ex01_AnonymousMethods_Generic_Param
    {
        static void Main(string[] args)
        {
            GenericType<string> printString;

            printString = delegate(string s)
            {
                Console.WriteLine(s);
                return s;
            };

            string str = printString("Alex");

            GenericType<int> printInt;

            printInt = delegate(int n)
            {
                Console.WriteLine(n);
                return n;
            };

            int num = printInt(10);

            Console.ReadKey();
        }
    }
}
