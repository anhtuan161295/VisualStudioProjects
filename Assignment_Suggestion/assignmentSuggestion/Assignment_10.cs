using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_10
    {
        public void easy()
        {
            easy.Test a = new easy.Test();
            a.marks();
            a.time();
            a.question();
        }
        public void middle()
        {
            middle.Test a = new middle.Test();
            a.marks();
            a.time();
            a.question();
        }
        public void difficult()
        {
            difficult.Test a = new difficult.Test();
            a.marks();
            a.time();
            a.question();

        }
        public void mandatory()
        {
            mandatory.Test a = new mandatory.Test();
            a.marks();
            a.time();
            a.question();
        }
        public void rule()
        {
            rule.Test a = new rule.Test();
            a.content();
        }
        public void team()
        {
            team.Test a = new team.Test();
            a.marks();
        }
        static void Main(string[] args)
        {
            Assignment_10 get = new Assignment_10();

            int choice;
            do
            {
                Console.WriteLine("Please choose an option...");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Middle");
                Console.WriteLine("3. Difficult");
                Console.WriteLine("4. Mandatory");
                Console.WriteLine("5. Rule");
                Console.WriteLine("6. Team");
                Console.WriteLine("7. Exit");
                Console.Write("Your choice (1-7): ");
                choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:

                        Console.WriteLine("-------------------- Easy --------------------");
                        get.easy();
                        break;
                    case 2:
                        Console.WriteLine("-------------------- Middle --------------------");
                        get.middle();
                        break;
                    case 3:
                        Console.WriteLine("-------------------- Difficult --------------------");
                        get.difficult();
                        break;
                    case 4:
                        Console.WriteLine("-------------------- Mandatory --------------------");
                        get.mandatory();
                        break;
                    case 5:
                        Console.WriteLine("-------------------- Rule --------------------");
                        get.rule();
                        break;
                    case 6:
                        Console.WriteLine("-------------------- Time --------------------");
                        get.team();
                        break;
                }
            } while (choice != 7);
        }
    }
}
namespace easy
{
    class Test
    {
        public void marks()
        {
            Console.WriteLine("total of marks: 60");
        }
        public void time()
        {
            Console.WriteLine("total of time: 1 h");
        }
        public void question()
        {
            Console.WriteLine("total of question: 60");
        }
    }
}
namespace middle
{
    class Test
    {
        public void marks()
        {
            Console.WriteLine("total of marks: 80");
        }
        public void time()
        {
            Console.WriteLine("total of time: 1 h");
        }
        public void question()
        {
            Console.WriteLine("total of question: 60");
        }
    }
}

namespace difficult
{
    class Test
    {
        public void marks()
        {
            Console.WriteLine("total of marks: 100");
        }
        public void time()
        {
            Console.WriteLine("total of time: 1 h");
        }
        public void question()
        {
            Console.WriteLine("total of question: 60");
        }
    }
}
namespace mandatory
{
    class Test
    {
        public void marks()
        {
            Console.WriteLine("total of marks: 70");
        }
        public void time()
        {
            Console.WriteLine("total of time: 1 h");
        }
        public void question()
        {
            Console.WriteLine("total of question: 60");
        }
    }
}
namespace rule
{
    class Test
    {
        public void content()
        {
            Console.WriteLine("try yourself");
        }
    }
}
namespace team
{
    class Test
    {
        public void marks()
        {
            Console.WriteLine(" Fish \n bear \n monkey");
        }
    }
}
