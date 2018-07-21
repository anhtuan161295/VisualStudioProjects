using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session10_Exception
{
    class Ex02_MultipleCatch
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a whole number: ");
                int num = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Please, try again.");
            }
            Console.ReadKey();
        }
    }
}
