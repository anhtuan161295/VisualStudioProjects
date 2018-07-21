﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace finalReview
{
    class Application
    {
        public void menu()
        {
            //Khởi tạo đối tượng PupilsManagement và gắn method vào delegate tương ứng
            PupilsManagement app = new PupilsManagement();
            Display insert, select, search;
            insert = new Display(app.addPupils);
            select = new Display(app.showPupils);
            search = new Display(app.searchPupils);

            int choose; //Chọn 1 số trong menu
            String ans; //Chọn Yes No khi Continue
            bool isNum; //Boolean kiểm tra nhập vào phải là số
            String temp; //Biến phụ để lấy string so sánh với pattern regex
            String numberPattern = @"^\d+$"; //Pattern của regex, phải là số, dấu @ để giữ giá trị nguyên gốc, ko cần backslash (verbatim string)
            Regex regex = new Regex(numberPattern); //Gắn pattern vào regex

            do
            {
                //Menu hiển thị
                Console.WriteLine("---------------------------");
                Console.WriteLine(" 1. Add new pupils");
                Console.WriteLine(" 2. Display all information");
                Console.WriteLine(" 3. Search pupils by name");
                Console.WriteLine(" 4. Quit");
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
                                insert();
                                break;

                            case 2:
                                select();
                                break;

                            case 3:
                                search();
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
            Application test = new Application();
            test.menu();
        }
    }
}