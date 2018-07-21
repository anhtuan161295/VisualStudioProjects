/*
 * An indexer provides array-like access to an object
  - Useful if a property can have multiple values
  - Known as smart array
  - Allows to use the index of an object to access the values in object 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session08_Properties_Indexers
{
    class Ex02_Indexer
    {
        private int[] initPassword = new int[25];
        //Indexer
        public int this[int index]
        {
            get
            {
                if ((index < 0) || (index > 25))
                {
                    return 0;
                }
                return initPassword[index];
            }
            set
            {
                if (!(index < 0) || (index > 25))
                {
                    initPassword[index] = value;
                }
            }
        }
        static void Main(string[] args)
        {
            Ex02_Indexer admin = new Ex02_Indexer();
            //Set Password
            for(int i = 0; i<20; i++)
            {
                admin.initPassword[i] = 123;
            }
            //Report Password
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Password of Student no.{0}\t: {1}", (i+1), admin.initPassword[i]);
            }
            Console.ReadKey();
        }
    }
}
