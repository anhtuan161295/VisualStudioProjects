using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace assignmentSuggestion
{
    class Assignment_13
    {
        static void Main(string[] args)
        {
            /*--- Question 1 ---*/

            ArrayList exhibition = new ArrayList();
            ArrayList exhibit = new ArrayList();
            ArrayList person = new ArrayList();
            ArrayList subject = new ArrayList();
            ArrayList floor = new ArrayList();
            ArrayList building = new ArrayList();

            //List exhibit
            exhibit.Add("Student01");
            exhibit.Add("Student02");
            exhibit.Add("Student03");
            exhibit.Add("Student04");
            exhibit.Add("Student05");
            exhibit.Add("Student06");
            exhibit.Add("Student07");
            exhibit.Add("Student08");
            exhibit.Add("Student09");
            exhibit.Add("Student10");
            exhibit.Add("Student11");
            exhibit.Add("Student12");
            exhibit.Add("Student13");
            exhibit.Add("Student14");
            exhibit.Add("Student15");

            //List person
            person.Add("Person01");
            person.Add("Person02");
            person.Add("Person03");
            person.Add("Person04");
            person.Add("Person05");
            person.Add("Person06");
            person.Add("Person07");
            person.Add("Person08");
            person.Add("Person09");
            person.Add("Person10");
            person.Add("Person11");
            person.Add("Person12");
            person.Add("Person13");
            person.Add("Person14");
            person.Add("Person15");

            //List Subject
            subject.Add("Subject01");
            subject.Add("Subject02");
            subject.Add("Subject03");
            subject.Add("Subject04");
            subject.Add("Subject05");
            subject.Add("Subject06");
            subject.Add("Subject07");
            subject.Add("Subject08");
            subject.Add("Subject09");
            subject.Add("Subject10");
            subject.Add("Subject11");
            subject.Add("Subject12");
            subject.Add("Subject13");
            subject.Add("Subject14");
            subject.Add("Subject15");

            //List floor
            floor.Add("01");
            floor.Add("02");
            floor.Add("03");
            floor.Add("04");
            floor.Add("05");
            floor.Add("06");
            floor.Add("07");
            floor.Add("08");
            floor.Add("09");
            floor.Add("10");
            floor.Add("11");
            floor.Add("12");
            floor.Add("13");
            floor.Add("14");
            floor.Add("15");

            //List Subject
            building.Add("Primary");
            building.Add("Primary");
            building.Add("Primary");
            building.Add("Primary");
            building.Add("Primary");
            building.Add("Higher");
            building.Add("Higher");
            building.Add("Higher");
            building.Add("Higher");
            building.Add("Higher");
            building.Add("Labs");
            building.Add("Labs");
            building.Add("Labs");
            building.Add("Labs");
            building.Add("Labs");

            //List exhibition
            exhibition.Add(exhibit);
            exhibition.Add(person);
            exhibition.Add(subject);
            exhibition.Add(floor);
            exhibition.Add(building);

            //Print ArrayList Multiple
            ArrayList list1 = (ArrayList)exhibition[0];
            ArrayList list2 = (ArrayList)exhibition[1];
            ArrayList list3 = (ArrayList)exhibition[2];
            ArrayList list4 = (ArrayList)exhibition[3];
            ArrayList list5 = (ArrayList)exhibition[4];

            Console.WriteLine("\t\t\tArrayList");
            Console.WriteLine("Exhibit\t\tPerson\t\tSubject\t\tFloor\tBuilding");
            Console.WriteLine("----------------------------------------------------------------------------");
            for (int i = 0; i < list1.Count; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", list1[i], list2[i], list3[i], list4[i], list5[i]);
            }
            Console.WriteLine("\n");

            /*--- Question 2 ---*/
            Hashtable objHashtable = new Hashtable();
            Console.WriteLine("\t\tHash Table");
            objHashtable.Add(1, "This is text");
            objHashtable.Add(2, "This is text");
            objHashtable.Add(3, "This is text");
            objHashtable.Add(4, "This is text");
            objHashtable.Add(5, "This is text");
            objHashtable.Add(6, "This is text");
            objHashtable.Add(7, "This is text");
            objHashtable.Add(8, "This is text");
            objHashtable.Add(9, "This...");
            objHashtable.Add(10, "This is text");
            objHashtable.Add(11, "This is text");
            objHashtable.Add(12, "This is text");
            objHashtable.Add(13, "This is text");
            objHashtable.Add(14, "This is text");
            objHashtable.Add(15, "This is text");
            objHashtable.Add(16, "This is text");
            Console.WriteLine("Number of elements in the hash table : " + objHashtable.Count);
            ICollection objCollection = objHashtable.Keys;
            Console.WriteLine("Original values stored in hash table are:");
            foreach (int i in objCollection)
            {
                Console.WriteLine(i + ":" + objHashtable[i] + " ");
            }
            Console.Write("\n\nIn Addition, Characters were add on. That is : ");
            Console.WriteLine(objHashtable[9]);
        }
    }
}
