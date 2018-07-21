using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace finalReview
{
    public delegate void Display();

    class PupilsManagement
    {
        List<Pupils> list = new List<Pupils>();

        public void addPupils()
        {
            bool isNum; //Boolean kiểm tra nhập vào phải là số
            String temp; //Biến phụ để lấy string so sánh với pattern regex
            String numberPattern = @"^\d+$"; //Pattern của regex, phải là số 0-9, dấu @ để giữ giá trị nguyên gốc, ko cần backslash (verbatim string)
            Regex regex = new Regex(numberPattern); //Gắn pattern vào regex
            int temp1 = 0;
            Pupils pupil = new Pupils();
            Console.Write("Enter pupil name: ");
            pupil.Name = Console.ReadLine();

            do
            {
                Console.Write("Enter pupil age: ");
                temp = Console.ReadLine();
                isNum = regex.IsMatch(temp);
                //Kiểm tra dữ liệu nhập vào phải là số 0-9, ko thì báo lỗi và nhập lại
                if (isNum == true)
                {
                    //Chuyển từ String qua int
                    temp1 = int.Parse(temp);
                    //Age phải >0 và <=18 cho đúng điều kiện đề bài, ko thì báo lỗi và nhập lại
                    if (temp1 > 0 & temp1 <= 18)
                    {
                        pupil.Age = int.Parse(temp);
                    }
                    else
                    {
                        Console.WriteLine("Age must be from 1 to 18");
                    }
                }
                else
                {
                    Console.WriteLine("Age must be a number");
                }
            } while (isNum == false || temp1 <= 0 || temp1 > 18);

            Console.Write("Enter pupil nationality: ");
            pupil.Nationality = Console.ReadLine();
            list.Add(pupil);
        }

        public void showPupils()
        {
            //Kiểm tra list có phần tử mới show, ko thì báo lỗi No pupil
            if (list.Count > 0)
            {
                Console.WriteLine("Name\tAge\tNationality");
                Console.WriteLine("----------------------------");
                foreach (Pupils pupil in list)
                {
                    pupil.personalReport();
                }
                Console.WriteLine("----------------------------");
            }
            else
            {
                Console.WriteLine("No pupil to display");
            }
        }

        public void searchPupils()
        {
            List<Pupils> result = new List<Pupils>();
            int countResult = 0;
            String keyword;
            Console.Write("Enter a keyword: ");
            keyword = Console.ReadLine();
            //Kiểm tra list phải có phần tử mới search, ko thì báo lỗi No pupil to display
            if (list.Count > 0)
            {
                foreach (Pupils pupil in list)
                {
                    //Nếu name chứa keyword thì add pupil vào list result, và tăng biến đếm lên 1
                    //Dùng ToLower() cho cả 2 để search ko phân biệt hoa thường
                    if (pupil.Name.ToLower().Contains(keyword.ToLower()) == true)
                    {
                        result.Add(pupil);
                        countResult++;
                    }
                }
                //Nếu biến đếm lớn hơn 0 thì mới xuất ra kết quả, ngược lại thì báo lỗi No pupil to display
                if (countResult > 0)
                {
                    Console.WriteLine("Found {0} results", countResult);
                    Console.WriteLine("Name\tAge\tNationality");
                    Console.WriteLine("----------------------------");
                    foreach (Pupils pupil in result)
                    {
                        pupil.personalReport();
                    }
                    Console.WriteLine("----------------------------");
                }
                else
                {
                    Console.WriteLine("No pupil to display");
                }
            }
            else
            {
                Console.WriteLine("No pupil to display");
            }
        }
    }
}