using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session06_Inheritance_Polymorphism
{
    class SupperClass
    {
        protected int marks;
        
        public int getMarks()
        {
            return marks;
        }

    }
    class Ex01_BaseKeyword: SupperClass
    {
        public void setMarks(int x)
        {
            base.marks = x;
        }
        static void Main(string[] args)
        {
            int report;
            Ex01_BaseKeyword teacher = new Ex01_BaseKeyword();
            teacher.setMarks(10);           //Teacher give student mark
            report = teacher.getMarks();   //Ask student mark from Teacher

            Console.WriteLine("Student marks: {0}", report);

            Console.ReadKey();
        }
    }
}
