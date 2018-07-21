/*
 * A jagged array is an array whose elements are arrays.
 * The elements of a jagged array can be of different dimensions and sizes. 
 * A jagged array is sometimes called an "array of arrays.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session04_Arrays
{
    class Ex02_JaggedArrays
    {
        static void Main(string[] args)
        {
            // Declare the array of two elements:
            int[][] arr = new int[2][];

            // Initialize the elements:
            arr[0] = new int[5] {1, 3, 5, 7, 9};
            arr[1] = new int[4] {2, 4, 6, 8};

            // Display the array elements:
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write("Element({0}): ", i);

                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("{0} ", arr[i][j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
