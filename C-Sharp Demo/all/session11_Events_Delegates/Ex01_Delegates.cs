/*
 * Delegates are used to reference methods defined in a class.
 * Ability to refer to a method in the form of a parameter
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session11_Events_Delegates
{
    //Defining the delegate
    public delegate int Calculate(int x, int y);

    class Ex01_Delegates
    {
        //Creating methods that will be assigned to delegate
        int add(int x, int y)
        {
            return x + y;
        }
        
        static void Main(string[] args)
        {

            //Creating the class instance
            Ex01_Delegates ex = new Ex01_Delegates();
            
            //Creating the Delegate Instance
            Calculate calculate = ex.add;

            Console.Write("Please enter the first value: ");
            int n1 = Int16.Parse(Console.ReadLine());

            Console.Write("Please enter the second value: ");
            int n2 = Int16.Parse(Console.ReadLine());

            //Calling the methods via delegate objects
            int sum = calculate(n1, n2);
            
            Console.WriteLine("\nThe result:\n{0} + {1} = {2}", n1, n2, sum);
            Console.ReadKey();
        }
    }
}
