using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int a = 5;
            int b = -5;
            try
            {
                try
                {
                    if (a > 0)
                    {
                        throw new MyException();
                    }
                }
                catch (Exception)
                {
                }
                if (b < 0)
                {
                    throw new MyException2();
                }
            }
            catch (Exception)
            {
            }
        }

        private class MyException : Exception
        {
            public MyException()
            {
                Console.WriteLine("This is my exception");
            }
        }

        private class MyException2 : Exception
        {
            public MyException2()
            {
                Console.WriteLine("This is my exception2");
            }
        }
    }
}