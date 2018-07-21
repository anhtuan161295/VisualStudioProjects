/*
 * Variable-length array that can dynamically increase or decrease in size.
 * Can store elements of different data types. 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session12_Collections
{
    class Ex01_ArrayList
    {
        static void Main(string[] args)
        {
            //Creating an empty ArrayList
            ArrayList list = new ArrayList();

            //Adding item into array
            list.Add("Alex");     //Add a string
            list.Add(10);         //Add an integer

            //Accessing elements
            foreach (object values in list)
            {
                Console.WriteLine(" {0}", values);
            }
            
            //Adding an elemet at index
            list.Insert(2, "C Sharp");

            //Accessing elements by another way
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Element [{0}] is {1}", i, list[i]);
            }

            Console.ReadKey();
        }
    }
}
