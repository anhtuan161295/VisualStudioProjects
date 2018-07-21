/*
 *Read      :reading the next character
 *ReadLine  :reading the entire input line 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session01_Variable_DataTypes
{
    class Ex04_ReadLine_Convert
    {
        static void Main(string[] args)
        {
            int min;
            int max;
            int avg;

            Console.Write("Minimum Temperature: ");
            min = Convert.ToInt16(Console.ReadLine());

            Console.Write("Maximum Temperature: ");
            max = Convert.ToInt16(Console.ReadLine());

            avg = (min + max)/2;
            
            Console.WriteLine("Average Temperature: {0}", avg);
            Console.ReadKey();
        }
    }
}
