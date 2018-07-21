using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_06_Sales
    {
        string Medicine_Code, Region;
        int Quantity_Sold, Planned_Sales, Actual_Sales;
        
        public Assignment_06_Sales() { }
        
        public Assignment_06_Sales(string mdc, int qs, int ps, int acs, string r)
        {
            Medicine_Code = mdc;
            Quantity_Sold = qs;
            Planned_Sales = ps;
            Actual_Sales = acs;
            Region = r;
        }
        public void accept()
        {
            Console.Write("Enter Medicine Code : ");
            Medicine_Code = Console.ReadLine();
            Console.Write("Enter Quantity Sold : ");
            Quantity_Sold = Int32.Parse(Console.ReadLine());
            Console.Write("Enter Planned Sales : ");
            Planned_Sales = Int32.Parse(Console.ReadLine());
            Console.Write("Enter Actual Sales : ");
            Actual_Sales = Int32.Parse(Console.ReadLine());
            Console.Write("Enter Region : ");
            Region = Console.ReadLine();
        }
        public void print()
        {
            Console.WriteLine("\n\t\tSales Informations");
            Console.WriteLine("\nCode : {0}", Medicine_Code);
            Console.WriteLine("Quantity Sold: {0}", Quantity_Sold);
            Console.WriteLine("Planned Sales : {0}", Planned_Sales);
            Console.WriteLine("Actual Sales : {0}", Actual_Sales);
            Console.WriteLine("Region : {0}", Region);
        }
        public void print(string requiredCode)
        {
            if (requiredCode == Medicine_Code)
            {
                Console.WriteLine("\n\t\tSales Informations Required");
                Console.WriteLine("Code : {0}", Medicine_Code);
                Console.WriteLine("Planned Sales : {0}", Planned_Sales);
                Console.WriteLine("Actual Sales : {0}", Actual_Sales);
            }
            else
                Console.WriteLine("This Code is invalid !!");
        }
    }
}
