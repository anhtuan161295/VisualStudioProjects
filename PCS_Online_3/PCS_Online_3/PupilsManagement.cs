using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PCS_Online_3
{
    public delegate void Display();

    class PupilsManagement
    {
        List<Pupils> list = new List<Pupils>();

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

        public int CheckAge()
        {
            bool isNum;
            bool isAge = false;

            string temp;
            int temp2 = 0;
            do
            {
                Console.Write("Enter pupil age: ");
                temp = Console.ReadLine();
                isNum = Check(@"^[0-9]+$", temp);
                if (isNum == true)
                {
                    temp2 = int.Parse(temp);
                    isAge = temp2 > 0 & temp2 <= 18;
                    if (isAge == true)
                    {
                        return temp2;
                    }
                    else
                    {
                        Console.WriteLine("Age must be from 1 to 18 only");
                    }
                }
                else
                {
                    Console.WriteLine("Age must be a number");
                }
            } while (isNum == false || isAge == false);
            return temp2;
        }

        public void addPupils()
        {
            Pupils pupil = new Pupils();
            Console.Write("Enter pupil name: ");
            pupil.Name = Console.ReadLine();
            //Console.Write("Enter pupil age: ");
            pupil.Age = CheckAge();
            Console.Write("Enter pupil nationality: ");
            pupil.Nationality = Console.ReadLine();
            list.Add(pupil);
        }

        public void showPupils()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].personalReport();
            }
        }
    }
}