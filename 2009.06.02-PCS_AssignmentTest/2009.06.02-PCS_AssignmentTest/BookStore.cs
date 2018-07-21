using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2009._06._02_PCS_AssignmentTest
{
    class BookStore
    {
        private int nextBook = 0;
        private string search;
        Books[] book = new Books[2];

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

        public int CheckNumber(string message, string error) /* Validate kiểm tra price, edition phải là số và trả về int */
        {
            bool check;
            string temp;
            int temp2 = 0;
            do
            {
                Console.Write(message);
                temp = Console.ReadLine();
                check = Check(@"^[0-9]+$", temp);
                if (check == true)
                {
                    temp2 = int.Parse(temp);
                }
                else
                {
                    Console.WriteLine(error);
                }
            } while (check == false);
            return temp2;
        }

        public void addBook()
        {
            if (nextBook < book.Length)
            {
                Books book1 = new Books();
                Console.Write("Enter book type: ");
                book1.Type = Console.ReadLine();
                Console.Write("Enter book title: ");
                book1.Title = Console.ReadLine();
                book1.Price = CheckNumber("Enter book price: ", "Book price must be a number");
                book1.Edition = CheckNumber("Enter book edition: ", "Book edition must be a number");
                book[nextBook] = book1;
                nextBook++;
            }
            else
            {
                Console.WriteLine("Unable to add book");
            }
        }

        public void displayBook()
        {
            if (nextBook == 0)
            {
                Console.WriteLine("No book to display");
            }

            for (int i = 0; i < nextBook; i++)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Book type: " + book[i].Type);
                Console.WriteLine("Book title: " + book[i].Title);
                Console.WriteLine("Book price: " + book[i].Price);
                Console.WriteLine("Book edition: " + book[i].Edition);
                Console.WriteLine("-----------------------------------");
            }
        }

        public void searchBook()
        {
            int count = 0;
            Console.Write("Enter a keyword: ");
            search = Console.ReadLine();

            for (int i = 0; i < nextBook; i++)
            {
                if (book[i].Title.ToLower().Contains(search.ToLower()) == true)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Book type: " + book[i].Type);
                    Console.WriteLine("Book title: " + book[i].Title);
                    Console.WriteLine("Book price: " + book[i].Price);
                    Console.WriteLine("Book edition: " + book[i].Edition);
                    Console.WriteLine("-----------------------------------");
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No book to display");
            }
        }

        public void menu()
        {
            BookStore store = new BookStore();

            int choose; //Chọn 1 số trong menu
            String ans; //Chọn Yes No khi Continue
            bool isNum; //Boolean kiểm tra nhập vào phải là số
            String temp; //Biến phụ để lấy string so sánh với pattern regex
            String numberPattern = @"^\d+$"; //Pattern của regex, phải là số 0-9, dấu @ để giữ giá trị nguyên gốc, ko cần backslash (verbatim string)
            Regex regex = new Regex(numberPattern); //Gắn pattern vào regex

            do
            {
                //Menu hiển thị
                Console.WriteLine("---------------------------");
                Console.WriteLine(" 1. Adding new book.");
                Console.WriteLine(" 2. Displaying all the details of books.");
                Console.WriteLine(" 3. Search book by the title");
                Console.WriteLine(" 4. Exit");
                Console.WriteLine("---------------------------");
                do
                {
                    //Nhập số, dữ liệu nhập vào dc gán vào temp, kiểm tra theo regex, trả về boolean
                    //Nếu đúng thì chạy switch case, sai thì báo nhập lại
                    Console.Write("Please choose an option: ");
                    temp = Console.ReadLine();
                    isNum = regex.IsMatch(temp);
                    if (isNum == true)
                    {
                        choose = int.Parse(temp);
                        switch (choose)
                        {
                            case 1:
                                store.addBook();
                                break;

                            case 2:
                                store.displayBook();
                                break;

                            case 3:
                                store.searchBook();
                                break;

                            case 4:
                                Console.WriteLine("Exit...");
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine("Error, your choice is not correct !");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number!");
                    }
                } while (isNum == false);
                //Chạy switch case xong thì hỏi Continue, Nếu Y thì lặp lại, ngược lại thì exit
                Console.Write("Continue (Y/N) ? ");
                ans = Console.ReadLine();
            } while (String.Equals(ans, "y", StringComparison.OrdinalIgnoreCase) == true);
        }

        static void Main(string[] args)
        {
            BookStore bookstore = new BookStore();
            bookstore.menu();
        }
    }
}