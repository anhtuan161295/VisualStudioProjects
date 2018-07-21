using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_02
    {
        static void Main(string[] args)
        {
            //Question 1: Declaration
            int min;
            int max;
            double avg;
            int popTown;
            int popState;
            bool metropolis;
            double avgLiteracy;
            string avgQualification;

            //Question 2: Declaration
            string studName;
            int studage;
            string gender;
            DateTime birthday;
            string address;
            string father;
            string mother;
            string fatherOccupation;
            bool citizen;
            string grade;
            string subject;

            //Question 1: input
            Console.WriteLine("*** Question 1 input ***");
            Console.Write("Minimum Temperature of the locality: ");
            min = Convert.ToInt16(Console.ReadLine());

            Console.Write("Maximum Temperature of the locality: ");
            max = Convert.ToInt16(Console.ReadLine());

            Console.Write("Average Temperature of the locality: ");
            avg = Convert.ToDouble(Console.ReadLine());

            Console.Write("Population of the town: ");
            popTown = Convert.ToInt16(Console.ReadLine());

            Console.Write("Population of the state: ");
            popState = Convert.ToInt16(Console.ReadLine());

            Console.Write("Whether the city is a metropolis or not (true/false data): ");
            metropolis = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Average literacy percentage of the city: ");
            avgLiteracy = Convert.ToDouble(Console.ReadLine());

            Console.Write("Average qualifications of the population: ");
            avgQualification = Convert.ToString(Console.ReadLine());

            //Question 2: Input
            Console.WriteLine("\n*** Question 2 input ***");
            Console.Write("Student Name: ");
            studName = Convert.ToString(Console.ReadLine());

            Console.Write("Student Age: ");
            studage = Convert.ToInt16(Console.ReadLine());

            Console.Write("Gender: ");
            gender = Convert.ToString(Console.ReadLine());

            Console.Write("birthday: ");
            birthday = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Address: ");
            address = Convert.ToString(Console.ReadLine());

            Console.Write("Father's Name: ");
            father = Convert.ToString(Console.ReadLine());

            Console.Write("Mother's Name: ");
            mother = Convert.ToString(Console.ReadLine());

            Console.Write("Father's Occupation: ");
            fatherOccupation = Convert.ToString(Console.ReadLine());

            Console.Write("Spanish Citizen (true/false): ");
            citizen = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Student Grade: ");
            grade = Convert.ToString(Console.ReadLine());

            Console.Write("Major Subject: ");
            subject = Convert.ToString(Console.ReadLine());

            //Question1: output
            Console.WriteLine("\n*** Question 1 output ***");
            Console.WriteLine("Minimum Temperature of the locality: {0}", min);
            Console.WriteLine("Maximum Temperature of the locality: {0}", max);
            Console.WriteLine("Average Temperature of the locality: {0}", avg);
            Console.WriteLine("Population of the town: {0}", popTown);
            Console.WriteLine("Population of the state: {0}", popState);
            Console.WriteLine("Whether the city is a metropolis: {0}", metropolis);
            Console.WriteLine("Average literacy percentage of the city: {0}", avgLiteracy);
            Console.WriteLine("Average qualifications of the population: {0}", avgQualification);


            //Question 2: Output
            Console.WriteLine("\n*** Question 2 output ***");
            Console.WriteLine("Student Name: {0}", studName);
            Console.WriteLine("Student Age: {0}", studage);
            Console.WriteLine("Gender: {0}", gender);
            Console.WriteLine("Birthday: {0}", birthday);
            Console.WriteLine("Address: {0}", address);
            Console.WriteLine("Father's Name: {0}", father);
            Console.WriteLine("Mother's Name: {0}", mother);
            Console.WriteLine("Father's Occupation: {0}", fatherOccupation);
            Console.WriteLine("Spanish Citizen (true/false): {0}", citizen);
            Console.WriteLine("Student Grade: {0}", grade);
            Console.WriteLine("Major Subject: {0}", subject);
        }
    }
}
