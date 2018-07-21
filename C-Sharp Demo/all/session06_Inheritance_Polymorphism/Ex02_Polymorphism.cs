using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session06_Inheritance_Polymorphism
{
    class A
    {
        public void overloadMethod()
        {
            Console.WriteLine("- Do something with no parameter");
        }
        
        public void overloadMethod(string s)
        {
            Console.WriteLine("\n- Display '{0}' {1}", s, " with parameter");
        }
        
        public void overloadMethod(string greeting, string name)
        {
            Console.WriteLine("\n{0}, {1}", greeting, name);
        }
    }
    class Ex02_Polymorphism
    {
        static void Main(string[] args)
        {
            A a = new A();
            Console.WriteLine("Calling overload method:\n");
            a.overloadMethod();
            a.overloadMethod("Hello");
            a.overloadMethod("GOODBYE", "Everybody");
            Console.WriteLine("SEE YOU NEXT WEEK.\nHAVE A NICE WEEKEND");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
