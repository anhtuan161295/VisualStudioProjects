/*
 * Adding a question mark (?) following the data type.
 * Using the generic Nullable<T> structure
 * (?) returns the left-hand operand if not null otherwise the right operand.
 * (??) the default value to be returned if assign a nullable type to a non-nullable type.

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session14_AnonymousMethods_Partial_Nullable
{
    class Ex03_Nullable
    {
        static void Main(string[] args)
        {
            int? x = null;
            int y = x ?? -1;
            Console.WriteLine("y when x is null: {0}", y);

            x = 10;
            y = x ?? -1;
            Console.WriteLine("y when x is {0}: {1}", x, y);

            Console.ReadKey();

        }
    }
}
