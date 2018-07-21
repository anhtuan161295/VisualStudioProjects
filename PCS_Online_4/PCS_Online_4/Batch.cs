using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PCS_Online_4
{
    public delegate void MyDelegate(String s);

    class Batch : IEnumerable
    {
        private String StudentCode;
        private String StudentName;
        private String Phone;
        private int Age;

        private ArrayList list = new ArrayList();

        public String AddCode
        {
            set { StudentCode = value; }
            get { return StudentCode; }
        }

        public String AddName
        {
            set { StudentName = value; }
            get { return StudentName; }
        }

        public String AddPhone
        {
            set { Phone = value; }
            get { return Phone; }
        }

        public int AddAge
        {
            set { Age = value; }
            get { return Age; }
        }

        public Batch()
        {
        }

        public Batch(string studentCode, string studentName, string phone, int age)
        {
            StudentCode = studentCode;
            StudentName = studentName;
            Phone = phone;
            Age = age;
        }

        public event MyDelegate MyEvent;

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

        public void warning(String s)
        {
            Console.WriteLine(s);
        }

        public void InputCode()
        {
            bool check;
            do
            {
                Console.Write("Enter Student Code: ");
                StudentCode = Console.ReadLine();
                check = Check(@"^[a-zA-Z]{3}-[0-9]{3}$", StudentCode);
                if (!check)
                {
                    MyEvent = new MyDelegate(warning);
                    MyEvent("Please enter code form AAA-xxx");
                }
                else
                {
                    AddCode = StudentCode;
                }
            } while (!check);
        }

        public void InputName()
        {
            bool check;
            do
            {
                Console.Write("Enter Student Name: ");
                StudentName = Console.ReadLine();
                check = Check(@"^[a-zA-Z ]+$", StudentName);
                if (!check)
                {
                    MyEvent = new MyDelegate(warning);
                    MyEvent("Please enter name form letters and spaces");
                }
                else
                {
                    AddName = StudentName;
                }
            } while (!check);
        }

        public void InputPhone()
        {
            bool check;
            do
            {
                Console.Write("Enter Student Phone: ");
                Phone = Console.ReadLine();
                check = Check(@"^[0-9]{3}-[0-9]{8}$", Phone);
                if (!check)
                {
                    MyEvent = new MyDelegate(warning);
                    MyEvent("Please enter phone form xxx-xxxxxxxx");
                }
                else
                {
                    AddPhone = Phone;
                }
            } while (!check);
        }

        public void InputAge()
        {
            bool check = false;
            bool isNum;
            String temp;
            int temp2 = 0;
            do
            {
                Console.Write("Enter Student Age: ");
                temp = Console.ReadLine();
                isNum = Check(@"^[0-9]+$", temp);
                if (isNum == true)
                {
                    temp2 = int.Parse(temp);
                    check = temp2 >= 10 & temp2 <= 50;
                    if (check == true)
                    {
                        AddAge = temp2;
                    }
                    else
                    {
                        MyEvent = new MyDelegate(warning);
                        MyEvent("Please enter age form 10 to 50");
                    }
                }
                else
                {
                    MyEvent = new MyDelegate(warning);
                    MyEvent("Age must be a number");
                }
            } while (check == false || isNum == false);
        }

        public void AddStudent()
        {
            InputCode();
            InputName();
            InputPhone();
            InputAge();
            list.Add(new Batch(StudentCode, StudentName, Phone, Age));
        }

        public void DisplayStudent()
        {
            if (list.Count > 0)
            {
                int j = 1;
                foreach (Batch bat in list)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Student {0} Information", j);
                    Console.WriteLine("Student Code {0}: {1}", j, bat.AddCode);
                    Console.WriteLine("Student Name {0}: {1}", j, bat.AddName);
                    Console.WriteLine("Student Phone {0}: {1}", j, bat.AddPhone);
                    Console.WriteLine("Student Age {0}: {1}", j, bat.AddAge);
                    Console.WriteLine("------------------------------------------");
                    j++;
                }
            }
            else
            {
                Console.WriteLine("No student to display");
            }
        }

        public void SearchStudentByName()
        {
            String keyword;
            int count = 0;
            ArrayList result = new ArrayList();
            Console.Write("Enter a name to search: ");
            keyword = Console.ReadLine();

            if (list.Count > 0)
            {
                foreach (Batch bat in list)
                {
                    if (bat.AddName.ToLower().Contains(keyword.ToLower()) == true)
                    {
                        count++;
                        result.Add(bat);
                    }
                }
                if (count > 0)
                {
                    int i = 1;
                    foreach (Batch bat in result)
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Student {0} Information", i);
                        Console.WriteLine("Student Code {0}: {1}", i, bat.AddCode);
                        Console.WriteLine("Student Name {0}: {1}", i, bat.AddName);
                        Console.WriteLine("Student Phone {0}: {1}", i, bat.AddPhone);
                        Console.WriteLine("Student Age {0}: {1}", i, bat.AddAge);
                        Console.WriteLine("------------------------------------------");
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine("No student to display");
                }
            }
            else
            {
                Console.WriteLine("No student to display");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return GetStudentCode();
        }

        public IEnumerator GetStudentCode()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }
    }
}