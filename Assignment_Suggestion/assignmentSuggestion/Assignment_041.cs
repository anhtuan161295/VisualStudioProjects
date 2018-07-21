using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_041
    {
        
        static void Main(string[] args)
        {
            string usersaved = "admin";
            string user = "";
            int choose = 0;
            double deposit;
            double withdraw;
            double balance = 0;
            double totaldeposit = 0;
            double totalwithdraw = 0;
            Console.WriteLine("Enter username:");
            user = Convert.ToString(Console.ReadLine());
            if (user == usersaved)
            {
                Console.WriteLine("1.Deposit");
                Console.WriteLine("2.Withdraw");
                Console.WriteLine("3.Display balance");
                Console.WriteLine("4.Exit");
                do
                {
                    Console.WriteLine("Enter your choice:");
                    choose = Convert.ToInt16(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            Console.WriteLine("Enter money you want to deposit:");
                            deposit = Convert.ToDouble(Console.ReadLine());
                            balance = balance + deposit;
                            totaldeposit = totaldeposit + deposit;
                            break;
                        case 2:
                            Console.WriteLine("Enter money you want to withdraw:");
                            withdraw = Convert.ToDouble(Console.ReadLine());
                            balance = balance - withdraw;
                            totalwithdraw = totalwithdraw + withdraw;
                            break;
                        case 3:
                            Console.WriteLine("- Today,total amount has been deposit:{0}", totaldeposit);
                            Console.WriteLine("- Today,total amount has been withdrawn:{0}", totalwithdraw);
                            Console.WriteLine("- Balance:{0}", balance);
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                    }
                } while (choose != 4);
            }
        }
    }
}
