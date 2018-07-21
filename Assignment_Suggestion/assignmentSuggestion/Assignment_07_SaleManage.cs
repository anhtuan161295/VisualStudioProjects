using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_07_SaleManage
    {
        Assignment_07_Sale[] saleArr;
        int count;
        public Assignment_07_SaleManage()
        {
            count = 0;
            saleArr = new Assignment_07_Sale[100];
        }

        public void accept()
        {
            if (count < saleArr.Length)
            {
                try
                {
                    int MedicineCode, QuantitySold, PlannedSale, ActualSale;
                    string region;
                    Console.WriteLine("-----------Input-----------");
                    Console.WriteLine("Medicine Code:");
                    MedicineCode = Int16.Parse(Console.ReadLine());
                    Console.WriteLine("Quantity Sold:");
                    QuantitySold = Int16.Parse(Console.ReadLine());
                    Console.WriteLine("Planned Sale:");
                    PlannedSale = Int16.Parse(Console.ReadLine());
                    Console.WriteLine("Actual Sale:");
                    ActualSale = Int16.Parse(Console.ReadLine());
                    Console.WriteLine("Region:");
                    region = Console.ReadLine();
                    saleArr[count] = new Assignment_07_Sale(MedicineCode, QuantitySold, PlannedSale, ActualSale, region);
                    count++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("List is full.");
            }
        }

        public void display()
        {
            Console.WriteLine("\n----*-*-*-*-List-*-*-*-*----");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(saleArr[i].getstring());
            }
        }

        public void display(int code)
        {
            Console.WriteLine("-----------Different planned sale and actual sale-----------");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Different:{0}", saleArr[i].PlannedSale1 - saleArr[i].ActualSale1);
            }
        }
    }
}
