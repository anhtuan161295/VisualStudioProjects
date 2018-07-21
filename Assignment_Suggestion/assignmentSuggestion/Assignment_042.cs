using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_042
    {
        static void Main(string[] args)
        {
            int result = 0;   //Diem cau hoi
            int bonus = 0;    //Diem thuong
            int total = 0;    //Diem tong = Result + bonus
            int index;      //Tuy chon menu
            bool[] check = new bool[4]; //Kiem tra cac cau hoi da lam hay chua 

            Console.WriteLine("**************************");
            Console.WriteLine("\t1.Aptitude");
            Console.WriteLine("\t2.English");
            Console.WriteLine("\t3.Mathematic");
            Console.WriteLine("\t4.General knowledge");
            Console.WriteLine("\t5.Exit");
            Console.WriteLine("**************************");

            do
            {
                Console.WriteLine("Please, choose an option for testing (1-5):");
                index = Convert.ToInt16(Console.ReadLine());
                if ((index > 0) && (index < 5))
                {
                    if (!check[index - 1])
                    {
                        switch (index)
                        {
                            case 1:
                                Console.WriteLine("You test Apptitude");
                                Console.WriteLine("1 + 0 = ?");
                                if (Console.ReadLine() == "1") result += 10;
                                break;
                            case 2:
                                Console.WriteLine("You test English");
                                Console.WriteLine("1 + 1 = ?");
                                if (Console.ReadLine() == "2") result += 10;
                                break;
                            case 3:
                                Console.WriteLine("You test Mathematic");
                                Console.WriteLine("1 + 2 = ?");
                                if (Console.ReadLine() == "3") result += 10;
                                break;
                            case 4:
                                Console.WriteLine("You test General knowledge");
                                Console.WriteLine("1 + 3 = ?");
                                if (Console.ReadLine() == "4") result += 10;
                                break;
                        }
                        check[index - 1] = true;
                    }
                    else
                        Console.WriteLine("This subject is already tested");
                } if (index == 5)
                {
                    Console.WriteLine("Finish the test...");
                }
            } while (index > 0 && index < 5);
            //Tinh diem bonus
            switch (result)
            {
                case 20: bonus = 2; break;
                case 30: bonus = 5; break;
                case 40: bonus = 10; break;
            }
            //Tinh diem tong
            total = result + bonus;
            Console.WriteLine("\n------- RESULT -------\n");
            Console.WriteLine("Bonus points earned: " + bonus);
            Console.WriteLine("Total score: " + total);

            switch (total)
            {
                case 0:
                    Console.WriteLine("You need to reappear the test");
                    break;
                case 10:
                    Console.WriteLine("Your IQ level is below average");
                    break;
                case 22:
                    Console.WriteLine("Your IQ level is average");
                    break;
                case 35:
                    Console.WriteLine("You are intelligent");
                    break;
                case 50:
                    Console.WriteLine("You are a genius");
                    break;
            }
        }
    }
}
