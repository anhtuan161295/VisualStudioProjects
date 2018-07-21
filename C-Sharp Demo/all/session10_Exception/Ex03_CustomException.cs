using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session10_Exception
{
    class MyException: Exception
    {
        public MyException() {}

        public MyException(string s): base(s)
        {
            Console.WriteLine("Custom Exception");
            Console.WriteLine("-------------------");
        }
    }
    class MyConnection
    {
        string con = null;
        public void doConnect()
        {
            if (con == null)
            {
                throw new MyException("Connection fails");
            }
            else
            {
                Console.WriteLine("Connection is established");
            }
        }
    }
    class Ex03_CustomException
    {
        static void Main(string[] args)
        {
            MyConnection cnn = new MyConnection();
            try
            {
                cnn.doConnect();
            }
            catch (MyException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
