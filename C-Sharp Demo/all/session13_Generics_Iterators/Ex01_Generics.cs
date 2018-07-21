using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session13_Generics_Iterators
{
    class MyGeneric<T>
    {
        T value;

        public MyGeneric(T value)
        {
            this.value = value;
        }

        public void printScreen()
        {
            Console.WriteLine(this.value);
        }
    }
    class Ex01_Generics
    {
        static void Main(string[] args)
        {
            MyGeneric<String> name = new MyGeneric<String>("Alex");
            MyGeneric<int> age = new MyGeneric<int>(30);
            name.printScreen();
            age.printScreen();

            Console.ReadKey();
        }
    }
}
