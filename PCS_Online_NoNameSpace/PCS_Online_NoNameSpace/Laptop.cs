using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PCS_Online_NoNameSpace
{
    class Laptop
    {
        ArrayList list = new ArrayList();

        private static Boolean Check(String temp, String input)
        {
            try
            {
                var rs = new Regex(temp);
                return rs.IsMatch(input);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public float CheckFloat()
        {
            bool check;
            string temp;
            float temp2;
            do
            {
                Console.Write("Enter computer price: ");
                temp = Console.ReadLine();
                check = float.TryParse(temp, out temp2);
                //if (check == true)
                //{
                //    temp2 = float.Parse(temp);
                //}
                //else
                //{
                //    Console.WriteLine("Price must be a float number");
                //}
                if (!check)
                {
                    Console.WriteLine("Price must be a float number");
                }
            } while (check == false);
            return temp2;
        }

        public int CheckInt()
        {
            bool check;
            string temp;
            int temp2;
            do
            {
                Console.Write("Enter computer year: ");
                temp = Console.ReadLine();
                check = int.TryParse(temp, out temp2);
                if (check == true)
                {
                    temp2 = int.Parse(temp);
                }
                else
                {
                    Console.WriteLine("Year must be a integer number");
                }
            } while (check == false);
            return temp2;
        }

        public void doAdd()
        {
            Computer com = new Computer();
            Console.Write("Enter computer id: ");
            com.Id = Console.ReadLine();
            com.Price = CheckFloat();
            com.Year = CheckInt();

            list.Add(com);
        }

        public void doList()
        {
            if (list.Count > 0)
            {
                foreach (Computer com in list)
                {
                    Console.WriteLine(com.ToString());
                }
            }
            else
            {
                Console.WriteLine("No computer to display");
            }
        }

        public void doSearch()
        {
            string search;
            int count = 0;
            ArrayList result = new ArrayList();
            Console.Write("Search by id: ");
            search = Console.ReadLine();
            if (list.Count > 0)
            {
                foreach (Computer com in list)
                {
                    if (com.Id.ToLower().Contains(search.ToLower()) == true)
                    {
                        result.Add(com);
                        count++;
                    }
                }
                if (count > 0)
                {
                    foreach (Computer com in result)
                    {
                        Console.WriteLine(com.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No computer to display");
                }
            }
            else
            {
                Console.WriteLine("No computer to display");
            }
        }
    }
}