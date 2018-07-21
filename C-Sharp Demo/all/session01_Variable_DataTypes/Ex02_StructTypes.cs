/*
 * A struct type is a value type that can contain:
   constructors, constants, fields, methods, properties, indexers, operators, events, and nested types.
 * The declaration of a struct takes the following form:

    [attributes] [modifiers] struct identifier [:interfaces] body [;]

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session01_Variable_DataType
{
    public struct student
    {
        public string name;
        public string subject;
        public float marks;

        public student(string a, string b, float c)
        {
            name = a;
            subject = b;
            marks = c;
        }
    }

    class Ex02_StructTypes
    {
        static void Main(string[] args)
        {
            // Initialize:   
            student sv = new student("Alex", "Java", 10.0F);

            // Display results:
            Console.WriteLine("Student information");
            Console.WriteLine(" - Name: {0}", sv.name);
            Console.WriteLine(" - Subject: {0}", sv.subject);
            Console.WriteLine(" - Marks: {0}", sv.marks);
            Console.ReadKey(); 
        }
    }
}
