using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session03_Constructs
{
    class Ex_Selection_Iteration
    {
        int option;
        String con;
        
        void show()
        {
            do
            {
                do
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("    1. Display word 'Hello'");
                    Console.WriteLine("    2. Display word 'Everybody'");
                    Console.WriteLine("    3. Exit");
                    Console.WriteLine("---------------------------");

                    Console.WriteLine("Please, choose option:(1-3): ");
                    option = Convert.ToInt16(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Hello");
                            break;
                        case 2:
                            Console.WriteLine("Everybody");
                            break;
                        case 3:
                            Console.WriteLine("Exit ...");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Oop! Your choice isnot correct!");
                            break;
                    }

                } while (option < 1 || option > 3);
                Console.WriteLine("Continue (y/n) ");
                con = Console.ReadLine();
            } while (con.ToUpper().Equals("Y"));
        }
        static void Main(string[] args)
        {
            Ex_Selection_Iteration select = new Ex_Selection_Iteration();
            select.show();
            Console.ReadKey();
        }
    }
}
