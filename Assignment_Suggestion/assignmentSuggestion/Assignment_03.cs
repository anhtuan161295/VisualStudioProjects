using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_03
    {
        static void Main(string[] args)
        {
            int packages, distance, travel = 0, feedback = 0;
            double Shifts, result = 0;
            //Every employee gets $50 for every package they deliver
            Console.WriteLine("Number of packages being deliver: ");
            packages = Convert.ToInt32(Console.ReadLine());    //packages = Int32.Parse(Console.ReadLine());

            //Every employee gets a daily $75 for their travel with distance(0-10km)
            Console.WriteLine("The distance they travel: ");
            distance = Convert.ToInt32(Console.ReadLine());//travel = Int32.Parse(Console.ReadLine());

            if ((distance > 0) && (distance <= 10))
            {
                travel = 75;
            }
            else if (distance > 10)
            {
                travel = 100;
            }
            else
            {
                Console.WriteLine("Wrong input");
            }

            result = packages * 50 + travel;

            //The night shift get an extra pay of 10% more than people working in day shift (0/1/2).
            Console.WriteLine("Shift: ");
            Shifts = Int32.Parse(Console.ReadLine());

            //Feedback from the customers.
            Console.WriteLine("Customer feedback (1/2/3/4): ");
            feedback = Convert.ToInt32(Console.ReadLine()); ;   //feedback = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\n\n*** SALARY MONTH OF EMPLOYEE ***");
            Console.WriteLine("Money of {0} package(s) : {1:C}", packages, packages * 50);
            Console.WriteLine("Money for their travel : {0:C}", travel);

            if (Shifts == 1)
            {
                Console.WriteLine("Salary for shift 1 : {0:C}", ((result * 0.1 + result) * 30));
            }
            else if (Shifts == 2)
            {
                Console.WriteLine("Salary for shift 2 : {0:C}", ((result * 0.2 + result) * 30));
            }
            else
            {
                Console.WriteLine("Salary for shift 3 : {0:C}", result * 30);
            }

            switch (feedback)
            {
                default:
                    Console.WriteLine("Feedback from the customers : Bad.");
                    break;
                case 1:
                    Console.WriteLine("Feedback from the customers : Excelent.");
                    break;
                case 2:
                    Console.WriteLine("Feedback from the customers : Good.");
                    break;
                case 3:
                    Console.WriteLine("Feedback from the customers : Normal.");
                    break;
            }
        }
    }
}
