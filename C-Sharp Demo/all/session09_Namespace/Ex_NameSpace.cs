using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session09_NameSpace
{
    class NameSpace
    {
        public void nameSpaceMethod()
        {
            Console.WriteLine("Call method in the same session09_NameSpace");
        }
    }
    
    namespace NestedNameSpace   //Nested Namespace
    {
        class NameSpace
        {
            public void nameSpaceMethod()
            {
                Console.WriteLine("Call method inside NestedNameSpace");
            }
        }
    } //End namespace NestedNamespace

    class Ex_NameSpace
    {
        static void Main(string[] args)
        {
            
            NameSpace outer = new NameSpace();
            outer.nameSpaceMethod();

            NestedNameSpace.NameSpace inner = new NestedNameSpace.NameSpace();
            inner.nameSpaceMethod();
            Console.ReadKey();
        }
    }
}