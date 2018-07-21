using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_01
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Welcome to Venice ***");
            Console.WriteLine("- You're reduced 40% fees right away.");
            Console.WriteLine("- List of our branches that you can browse its details.\n");
            Console.WriteLine("Branches\tCourses\tFees\tDuration");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Bangladesh\t{0}\t{1:C}\t{2} Year", "DISM", 1700, 1);
            Console.WriteLine("Pakistan\t{0}\t{1:C}\t{2} Year", "HDSE", 2500, 2);
        }
    }
}
