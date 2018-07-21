using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_09_Index
    {
        string[,] name = new string[15, 3];
        //string[] id = new string[15];
        //double[] rate = new double[15];
        public string this[int i, int j]
        {
            set
            {
                if (j == 0)
                    name[i, 0] = value;
                if (j == 1)
                    name[i, 1] = value;
                if (j == 2)
                    name[i, 2] = value;
            }

        }
        public void display()
        {
            int i;
            //int k = 0;
            Console.WriteLine("----------------------Louis-Supermarket------------------------");
            Console.WriteLine("\tName\t\t\tID\t\tRate/Kg");

            for (i = 0; i < name.GetLength(0); i++)
            {
                Console.WriteLine("\t{0}\t\t{1}\t\t{2}", name[i, 0], name[i, 1], name[i, 2]);
            }

        }
    }
}
