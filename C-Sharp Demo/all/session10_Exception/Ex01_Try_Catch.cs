using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session10_Exception
{
    class Ex01_Try_Catch
    {
        static void Main(string[] args)
        {
            int[] num = new int[3] { 1, 2, 3 };
            try
            {
                //Console.WriteLine(num[2]);    //Correct
                Console.WriteLine(num[3]);      //Incorrect
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
