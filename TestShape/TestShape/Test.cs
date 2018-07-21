using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShape
{
    class Test
    {
        public void menu()
        {
            string choose; //Chọn 1 số trong menu
            string ans; //Chọn Yes No khi Continue
            bool isNum; //Boolean kiểm tra nhập vào phải là số
            String temp; //Biến phụ để lấy string so sánh với pattern regex
            //String numberPattern = @"^\d+$"; //Pattern của regex, phải là số 0-9, dấu @ để giữ giá trị nguyên gốc, ko cần backslash (verbatim string)
            //Regex regex = new Regex(numberPattern); //Gắn pattern vào regex
            ShapeCollection shape = new ShapeCollection();

            do
            {
                //Menu hiển thị, gõ chữ vào để chạy, ví dụ gõ Circle để add Circle
                Console.WriteLine("---------------------------");
                Console.WriteLine(" 1. Circle");
                Console.WriteLine(" 2. Rectangle");
                Console.WriteLine(" 3. Show");
                Console.WriteLine(" 4. Quit");
                Console.WriteLine("---------------------------");
                do
                {
                    //Nhập số, dữ liệu nhập vào dc gán vào temp, kiểm tra theo regex, trả về boolean
                    //Nếu đúng thì chạy switch case, sai thì báo nhập lại
                    Console.Write("Please enter a word: ");
                    choose = Console.ReadLine();
                    /*Xài try parse thì ko cần regex
                     * nếu có thể parse (isNum trả về true) thì tự động parse và gắn cho choose giá trị của temp,
                     * Ngược lại, nếu ko parse dc (isNum trả về false) và gắn cho choose giá trị 0
                     */
                    //isNum = int.TryParse(temp, out choose);
                    //if (isNum == true)
                    //{
                    //choose = int.Parse(temp);
                    switch (choose)
                    {
                        case "Circle":
                            shape.AddCircle();
                            break;

                        case "Rectangle":
                            shape.AddRectangle();
                            break;

                        case "Show":
                            shape.Show();
                            break;

                        case "Quit":
                            Console.WriteLine("Quiting...");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Error, your choice is not correct !");
                            break;
                    }
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Please enter a number!");
                    //}
                } while (choose != "Circle" & choose != "Rectangle" & choose != "Show" & choose != "Quit");
                //Chạy switch case xong thì hỏi Continue, Nếu Y thì lặp lại, ngược lại thì exit
                Console.Write("Continue (Y/N) ? ");
                ans = Console.ReadLine();
            } while (String.Equals(ans, "y", StringComparison.OrdinalIgnoreCase) == true);
        }

        private static void Main(string[] args)
        {
            Test test = new Test();
            test.menu();
        }
    }
}