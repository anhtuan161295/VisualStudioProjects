using System;
using System.Text.RegularExpressions; //Phải có thư viện này mới dùng regex được

namespace MenuDemo
{
    internal class MenuTest
    {
        public void menu()
        {
            int choose; //Chọn 1 số trong menu
            String ans; //Chọn Yes No khi Continue
            bool isNum; //Boolean kiểm tra nhập vào phải là số
            String temp; //Biến phụ để lấy string so sánh với pattern regex
            //String numberPattern = @"^\d+$"; //Pattern của regex, phải là số 0-9, dấu @ để giữ giá trị nguyên gốc, ko cần backslash (verbatim string)
            //Regex regex = new Regex(numberPattern); //Gắn pattern vào regex

            do
            {
                //Menu hiển thị
                Console.WriteLine("---------------------------");
                Console.WriteLine(" 1. Display word 'Hello'");
                Console.WriteLine(" 2. Display word 'Everybody'");
                Console.WriteLine(" 3. Exit");
                Console.WriteLine("---------------------------");
                do
                {
                    //Nhập số, dữ liệu nhập vào dc gán vào temp, kiểm tra theo regex, trả về boolean
                    //Nếu đúng thì chạy switch case, sai thì báo nhập lại
                    Console.Write("Please choose an option: ");
                    temp = Console.ReadLine();
                    /*Xài try parse thì ko cần regex
                     * nếu có thể parse (isNum trả về true) thì tự động parse và gắn cho choose giá trị của temp,
                     * Ngược lại, nếu ko parse dc (isNum trả về false) và gắn cho choose giá trị 0
                     */
                    isNum = int.TryParse(temp, out choose);
                    if (isNum == true)
                    {
                        //choose = int.Parse(temp);
                        switch (choose)
                        {
                            case 1:
                                Console.WriteLine("Hello");
                                break;

                            case 2:
                                Console.WriteLine("Everybody");
                                break;

                            case 3:
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

        private static void Main(string[] args)
        {
            MenuTest test = new MenuTest();
            test.menu();
        }
    }
}