using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session14_AnonymousMethods_Partial_Nullable
{
    class Ex02_PartialType: PartialType<int>
    {
        void add(int x, int y)
        {
            Console.WriteLine("{0} + {1} = {2}", x, y, (x + y));
        }

        void sub(int x, int y)
        {
            Console.WriteLine("{0} - {1} = {2}", x, y, (x - y));
        }

        static void Main(string[] args)
        {
            int a = 10, b = 5;
            Ex02_PartialType cal = new Ex02_PartialType();

            cal.add(a, b);
            cal.sub(a, b);

            Console.ReadKey();
        }
    }
}
