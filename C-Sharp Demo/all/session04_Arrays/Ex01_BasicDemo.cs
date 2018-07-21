using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session04_Arrays
{
    class Ex01_BasicDemo
    {
        static void Main(string[] args)
        {
            // Single-dimensional array

            int i, j;
            int[] single = new int[3];
            
            Console.WriteLine("Enter Single-dimensional array values: ");
            for (i = 0; i < single.Length; i++)
            {
                single[i] = Convert.ToInt16(Console.ReadLine());
            }
            for (i = 0; i < single.Length; i++)
            {
                Console.WriteLine("single[{0}] = {1}", i, single[i]);
            }

            // Multidimensional array
            
            int[,] multi = new int[2,3];

            Console.WriteLine("\nEnter Multiple-dimensional array values: ");
            for (i = 0; i < multi.GetLength(0); i++)
            {
                for (j = 0; j < multi.GetLength(1); j++)
                {
                    multi[i, j] = Convert.ToInt16(Console.ReadLine());
                }
            }

            for (i = 0; i < 2; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    Console.WriteLine("multi[{0},{1}] = {2}", i, j, multi[i,j]);
                }
            }
            Console.ReadKey();
        }
    }
}
