/*
 * Traverse through a list of values or a collection.
 * Uses the “foreach” loop to refer to a collection of values in a sequential manner.
 * yield return statement stored the current location.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session13_Generics_Iterators
{
    public class DaysOfTheWeek : IEnumerable            //1. Use IEnumerable interface
    {
        private string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        public IEnumerator GetEnumerator()              //2. Use IEnumerable GetEnumerator() method
        {
            for (int i = 0; i < days.Length; i++)
            {
                yield return days[i];                   //3. yield return statement
            }
        }
    }

    internal class Ex04_Iterators
    {
        private static void Main(string[] args)
        {
            //Create an instance of the collection class
            DaysOfTheWeek week = new DaysOfTheWeek();

            //Iterate with foreach
            foreach (string day in week)
            {
                Console.Write(" {0}", day);
            }
            Console.ReadKey();
        }
    }
}