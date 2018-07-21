using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_07
    {
        static void Main(string[] args)
        {
            Assignment_07_SaleManage sm = new Assignment_07_SaleManage();
            bool flag = false;
            int select = -1;
            do
            {
                Console.WriteLine("--------------Menu--------------");
                Console.WriteLine("1. Add new");
                Console.WriteLine("2. Display all");
                Console.WriteLine("3. Display different");
                Console.WriteLine("4. Quit");
                do
                {
                    try
                    {
                        Console.WriteLine("\nChoose a number:");
                        select = Int16.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                while (select < 1 || select > 4);

                switch (select)
                {
                    case 1: sm.accept();
                        flag = true;
                        break;
                    case 2: if (!flag)
                        {
                            Console.WriteLine("List is null.");
                            break;
                        }
                        else
                        {
                            sm.display();
                            break;
                        }
                    case 3:
                        if (!flag)
                        {
                            Console.WriteLine("List is null.");
                            break;
                        }
                        else
                        {
                            int value;
                            try
                            {
                                Console.WriteLine("\nInput Medicine code:");
                                value = Int16.Parse(Console.ReadLine());
                                sm.display(value);
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                break;
                            }

                        }
                    case 4: break;
                }
            }
            while (select != 4);
        }
    }
}
