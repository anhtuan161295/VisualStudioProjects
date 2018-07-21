using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_09
    {
        static void Main(string[] args)
        {
            Assignment_09_Index obj = new Assignment_09_Index();
            int choice;
            //int i = 10;
            obj[0, 0] = "Cakes Mixer"; obj[0, 1] = "1"; obj[0, 2] = "90";
            obj[1, 0] = "Cookies Mixer"; obj[1, 1] = "2"; obj[1, 2] = "100";
            obj[2, 0] = "Sweetener"; obj[2, 1] = "3"; obj[2, 2] = "100";
            obj[3, 0] = "Naturals Flavour"; obj[3, 1] = "4"; obj[3, 2] = "200";
            obj[4, 0] = "Corn Flours"; obj[4, 1] = "5"; obj[4, 2] = "150";
            obj[5, 0] = "Rice Flours"; obj[5, 1] = "6"; obj[5, 2] = "175";
            obj[6, 0] = "Corn Pasta"; obj[6, 1] = "7"; obj[6, 2] = "180";
            obj[7, 0] = "Rice Pasta"; obj[7, 1] = "8"; obj[7, 2] = "190";
            obj[8, 0] = "Snacks"; obj[8, 1] = "9"; obj[8, 2] = "100";
            obj[9, 0] = "Cereals"; obj[9, 1] = "10"; obj[9, 2] = "50";

            do
            {
                Console.WriteLine("-------------------- Authentic Supermarket --------------------");
                Console.WriteLine("Please choose an option...");
                Console.WriteLine("1. Input data");
                Console.WriteLine("2. Display data");
                Console.WriteLine("3. Quit");
                Console.Write("Your choice (1-3): ");
                choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        int k = 10;
                        Console.WriteLine("-------------------- Authentic Supermarket --------------------");
                        Console.WriteLine("---------------------------- input ----------------------------");
                        Console.WriteLine("Name: ");
                        obj[k, 0] = Console.ReadLine();
                        Console.WriteLine("id: ");
                        obj[k, 1] = Console.ReadLine();
                        Console.WriteLine("kg: ");
                        obj[k, 2] = Console.ReadLine();
                        k++;
                        break;
                    case 2:
                        obj.display();
                        break;
                    case 3:
                        break;
                }
            } while (choice != 3);
        }
    }
}
