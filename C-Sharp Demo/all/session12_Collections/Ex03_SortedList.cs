/*
 * Represents a collection of key/value pairs that are sorted by the keys
 * Accessible by key and by index.
 * See more msdn.microsoft.com/en-us/library/system.collections.sortedlist.aspx
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session12_Collections
{
    class Ex03_SortedList
    {
        static void display(string[] x, int[] y)
        {
            if (x.Length == y.Length)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    Console.WriteLine("Student rollno {0} has {1} marks", x[i], y[i]);
                }
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            //Creating an empty Hashtable
            SortedList table = new SortedList();
            
            //Adding item into Hashtable
            table.Add("GC001", 10);
            table.Add("GC002", 10);
            table.Add("GC003", 10);
            table.Add("GC004", 10);
            table.Add("GC005", 10);

            //Accessing elements
            Console.WriteLine("Two students have marks");
            foreach (String values in table.Keys)
            {
                Console.WriteLine("Student rollno {0} has {1} marks", values, table[values]);
            }
            Console.WriteLine();
            //Declaring student list
            string[] rollno = new string[5] { "ST001", "ST002", "ST003", "ST004", "ST005" };
            int[] marks = new int[5] { 0, 0, 0, 0, 0 };

            //Displaying student list
            Console.WriteLine("Before update List");
            display(rollno, marks);

            //Copy hastable to student list
            table.Keys.CopyTo(rollno, 0);
            table.Values.CopyTo(marks, 0);

            //Displaying student list
            Console.WriteLine("After update List");
            display(rollno, marks);

            //Remove student
            string no = "GC002";
            Console.WriteLine("Remove Student rollno {0} ", no);
            table.Remove(no);
            if (!table.ContainsKey(no))
            {
                Console.WriteLine("Student rollno {0} is not found.", no);
            }
            
            Console.ReadKey();
        }
    }
}
