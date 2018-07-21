using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalReview
{
    class Pupils : Person
    {
        private String name;
        private int age;
        private String nationality;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0 & value <= 18)
                {
                    age = value;
                }
            }
        }

        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        public override void personalReport()
        {
            Console.WriteLine("{0}\t{1}\t{2}", name, age, nationality);
        }
    }
}