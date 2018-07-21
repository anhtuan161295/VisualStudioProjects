using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_14
    {
        static void Main(string[] args)
        {

            Assignment_14_GenericDefaultList<Assignment_14_Library> gen = new Assignment_14_GenericDefaultList<Assignment_14_Library>(4);

            Assignment_14_Library lib  = new Assignment_14_Library("DungLX", 2, "Gone with the wind", "BK001", "2.2.2010", "3.3.2010");
            Assignment_14_Library lib1 = new Assignment_14_Library("Beckham", 3, "MU", "BK002", "3.2.2010", "10.3.2010");
            Assignment_14_Library lib2 = new Assignment_14_Library("David Villa", 1, "Barca", "BK003", "2.2.2010", "3.3.2010");
            Assignment_14_Library lib3 = new Assignment_14_Library("F.Torres", 1, "Chease", "BK004", "2.2.2010", "3.3.2010");

            gen.add(lib);
            gen.add(lib1);
            gen.add(lib2);
            gen.add(lib3);


            Console.WriteLine("Student Name\tYear\tBook name\tBook ID\tDate Issue\tDate Return");
            Console.WriteLine("=========\t===\t==================\t=========\t===========");

            foreach (Object obj in gen.Defaulter)
            {
                Console.WriteLine(obj);

            }
        }
    }
}
