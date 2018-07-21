using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PCS_Online_NoNameSpace
{
    class HPBrand
    {
        public void menu()
        {
            Laptop lap = new Laptop();

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
                Console.WriteLine(" 1. Add new laptop.");
                Console.WriteLine(" 2. Display all information.");
                Console.WriteLine(" 3. Search information.");
                Console.WriteLine(" 4. Quit.");
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
                                lap.doAdd();
                                break;

                            case 2:
                                lap.doList();
                                break;

                            case 3:
                                lap.doSearch();
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
            HPBrand test = new HPBrand();
            test.menu();
        }
    }
}