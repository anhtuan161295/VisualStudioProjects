using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session13_Generics_Iterators
{
    class Ex03_GenericsMethod
    {
        void swap<T>(ref T val1, ref T val2)
        {
            T tmp = val1;
            val1 = val2;
            val2 = tmp;
        }

        static void Main(string[] args)
        {
            int i1 = 10, i2 = 5;
            float f1 = 10F, f2 = 5F;
            Ex03_GenericsMethod math = new Ex03_GenericsMethod();
            
            //Swapping Integer
            Console.WriteLine("Before swap: i1 = {0}, i2 = {1}", i1, i2);

            math.swap<int>(ref i1, ref i2);
            Console.WriteLine("After swap: i1 = {0}, i2 = {1}", i1, i2);

            //Swapping Float
            Console.WriteLine("Before swap: f1 = {0}, f2 = {1}", f1, f2);

            math.swap<float>(ref f1, ref f2);
            Console.WriteLine("After swap: f1 = {0}, f2 = {1}", f1, f2);

            Console.ReadKey();
        }
    }
}
