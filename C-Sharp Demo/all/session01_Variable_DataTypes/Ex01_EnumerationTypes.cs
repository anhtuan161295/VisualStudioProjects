/*
 * Enumeration consisting of a set of named constants called the enumerator list.
 * Every enumeration type has an underlying type, which can be any integral type except char.
 * This declaration takes the following form::

         [attributes] [modifiers] enum identifier [:base-type] {enumerator-list} [;]

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session01_Variable_DataType
{
    class Ex01_EnumerationTypes
    {
        enum PhoneNo : int { Max = 12, Min = 8 };
        public static void Main()
        {
            int max = (int)PhoneNo.Max;
            int min = (int)PhoneNo.Min;
            Console.WriteLine("Phone is between in {0} and {1} characters", min, max);
            Console.ReadKey();
        }
    }
}
