using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_06
    {
        static void Main(string[] args)
        {
            int choice;
            int select;
            string requiredCode, requiredName;
            Assignment_06_Medicine mdicin = new Assignment_06_Medicine();
            Assignment_06_Sales sale = new Assignment_06_Sales();
            do
            {
                Console.WriteLine("\t-----Welcome to Noertis Pharma Ltd.-----");
                Console.WriteLine("1. View all the details of Medicine.");
                Console.WriteLine("2. View Sales.");
                Console.WriteLine("3. Exit.");
                Console.Write("Please choice 1-3: ");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("\n\t\tMedicine Informations");
                            Console.WriteLine("1. Accept new informations");
                            Console.WriteLine("2. View all the details of Sales");
                            Console.WriteLine("3. View Quantity On Hand");
                            Console.WriteLine("4. View Date");
                            Console.WriteLine("5. Exit.");
                            Console.Write("Please choice 1-5: ");
                            select = Int32.Parse(Console.ReadLine());
                            switch (select)
                            {
                                case 1: 
                                    mdicin.accept(); 
                                    break;
                                case 2: 
                                    mdicin.print(); 
                                    break;
                                case 3:
                                    Console.Write("Enter Medicine Code :");
                                    requiredCode = Console.ReadLine();
                                    mdicin.print(requiredCode);
                                    break;
                                case 4:
                                    Console.Write("Enter Medicine Code :");
                                    requiredCode = Console.ReadLine();
                                    Console.Write("Enter Medicine Name :");
                                    requiredName = Console.ReadLine();
                                    mdicin.print(requiredCode, requiredName);
                                    break;
                                default:
                                    break;
                            }
                        } while (select > 0 && select < 5);
                        break;
                    case 2:
                        do
                        {
                            Console.WriteLine("\n\t\tSales Informations");
                            Console.WriteLine("1. Accept new informations.");
                            Console.WriteLine("2. View all Sales details.");
                            Console.WriteLine("3. View actual sales and planned sales.");
                            Console.WriteLine("4. Exit.");
                            Console.Write("Please choice 1-4: ");
                            select = Int32.Parse(Console.ReadLine());
                            switch (select)
                            {
                                case 1: 
                                    sale.accept(); 
                                    break;
                                case 2: 
                                    sale.print(); 
                                    break;
                                case 3:
                                    Console.Write("Enter Medicine Code :");
                                    requiredCode = Console.ReadLine();
                                    sale.print(requiredCode);
                                    break;
                                default:
                                    break;
                            }
                        } while (select > 0 && select < 4);
                        break;
                    default:
                        break;
                }
            } while (choice > 0 && choice < 3);
        }
    }
}
