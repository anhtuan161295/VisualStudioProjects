using System;
using System.Text.RegularExpressions;

namespace regexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string code;
            bool reCheck;
            
            Console.WriteLine("Please input Employee's Code:");
            String re = "^[A][0-9]{3}$";

            code = Console.ReadLine();
            reCheck = Regex.IsMatch(code, re);

            if (!reCheck)
            {
                Console.WriteLine("Invalid value\n");
            }
            else
            {
                Console.WriteLine("Congratulation!");
            }

            Console.ReadKey();
        }
    }
}
