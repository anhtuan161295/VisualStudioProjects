using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS_Online_3
{
    class Pupils : Person
    {
        private string name;
        private int age;
        private string nationality;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        public override void personalReport()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Pupil name: " + name);
            Console.WriteLine("Pupil age: " + age);
            Console.WriteLine("Pupil nationality: " + nationality);
            Console.WriteLine("--------------------------------------");
        }
    }
}