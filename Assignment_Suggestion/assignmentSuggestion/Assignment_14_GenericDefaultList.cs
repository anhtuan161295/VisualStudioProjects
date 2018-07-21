using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_14_GenericDefaultList<T>
    {
        internal T[] Defaulter;
        internal int counter;
        public Assignment_14_GenericDefaultList(int max)
        {
            Defaulter = new T[max];
            counter = 0;

        }


        public void add(T obj)
        {
            try
            {

                if (counter < Defaulter.Length)
                {
                    Defaulter[counter] = obj;
                    counter++;
                }

                else
                {
                    throw new IndexOutOfRangeException("Index value exceed");
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
