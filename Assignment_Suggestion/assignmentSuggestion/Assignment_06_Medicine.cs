using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_06_Medicine
    {
        string Medicine_Code, Medicine_Name, Manufacturer_Name, Manufactured_Date, Expiry_Date;
        int Unit_Price, Quantity_On_Ha, Batch_Number;
        public Assignment_06_Medicine() { }

        public Assignment_06_Medicine(string mdc, string mnane, string mn, int up, int qoh, string md, string ed, int bn)
        {
            Medicine_Code = mdc;
            Medicine_Name = mnane;
            Manufacturer_Name = mn;
            Unit_Price = up;
            Quantity_On_Ha = qoh;
            Manufactured_Date = md;
            Expiry_Date = ed;
            Batch_Number = bn;
        }
        public void accept()
        {
            Console.Write("Enter Medicine Code : ");
            Medicine_Code = Console.ReadLine();
            Console.Write("Enter Medicine Name : ");
            Medicine_Name = Console.ReadLine();
            Console.Write("Enter Manufacturer Name : ");
            Manufacturer_Name = Console.ReadLine();
            Console.Write("Enter Unit Price : ");
            Unit_Price = Int32.Parse(Console.ReadLine());
            Console.Write("Enter Quantity On Hand : ");
            Quantity_On_Ha = Int32.Parse(Console.ReadLine());
            Console.Write("Enter Manufactured Date : ");
            Manufactured_Date = Console.ReadLine();
            Console.Write("Enter Expiry Date : ");
            Expiry_Date = Console.ReadLine();
            Console.Write("Enter Batch Number : ");
            Batch_Number = Int32.Parse(Console.ReadLine());
        }
        public void print()
        {
            Console.WriteLine("\n\t\tMedicine Informations");
            Console.WriteLine("\nMedicine Code : {0}", Medicine_Code);
            Console.WriteLine("Medicine Name : {0}", Medicine_Name);
            Console.WriteLine("Manufacturer Name : {0}", Manufacturer_Name);
            Console.WriteLine("Unit Price : {0}", Unit_Price);
            Console.WriteLine("Quantity On Hand : {0}", Quantity_On_Ha);
            Console.WriteLine("Manufactured Date : {0}", Manufactured_Date);
            Console.WriteLine("Expiry Date : {0}", Expiry_Date);
            Console.WriteLine("Batch Number : {0}", Batch_Number);
        }
        public void print(string requiredMedicine_Code)
        {
            if (requiredMedicine_Code == Medicine_Code)
            {
                Console.WriteLine("\n\t\tMedicine Informations Required");
                Console.WriteLine(" Medicine Code : {0}", Medicine_Code);
                Console.WriteLine(" Medicine Name : {0}", Medicine_Name);
                Console.WriteLine(" Quantity On Hand : {0}", Quantity_On_Ha);
            }
            else
                Console.WriteLine("This Medicine Code is not exist!");
        }

        public void print(string requiredMedicine_Code, string requiredMedicine_Name)
        {
            if (requiredMedicine_Code == Medicine_Code && requiredMedicine_Name == Medicine_Name)
            {
                Console.WriteLine("\n\t\tMedicine Informations Required");
                Console.WriteLine(" Medicine Code : {0}", Medicine_Code);
                Console.WriteLine(" Medicine Name : {0}", Medicine_Name);
                Console.WriteLine(" Manufactured Date : {0}", Manufactured_Date);
                Console.WriteLine(" Expiry Date : {0}", Expiry_Date);
            }
            else
                Console.WriteLine("This Medicine Code or this Medicine Name is not exist!");
        }
    }
}
