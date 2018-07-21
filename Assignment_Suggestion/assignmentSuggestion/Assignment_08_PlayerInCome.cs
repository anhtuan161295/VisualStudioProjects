using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_08_PlayerInCome: Assignment_08_Player, Assignment_08_ITax, Assignment_08_IBound
    {
        float inCome;
        float tax_percent, bounds_percent;

        public Assignment_08_PlayerInCome(String name, float i, float tp, float bp)
            : base(name)
        {
            this.inCome = i;
            this.tax_percent = tp;
            this.bounds_percent = bp;
        }


        public override void displayDetail()
        {
            Console.WriteLine("Ten: " + name);
            Console.WriteLine("Tien luong: " + inCome);
            Console.WriteLine("Thue thu nhap " + tax_percent);
            Console.WriteLine("Tien thuong: " + bounds_percent);
            Console.WriteLine("Tong thu nhap: " + ((inCome + bounds_percent) - tax_percent));
        }




        #region ITax Members

        public float caculateTax()
        {
            float TotalTax;
            TotalTax = inCome * tax_percent;
            Console.WriteLine("tong thu nhap la : " + TotalTax);
            return TotalTax;
        }

        #endregion

        #region IBound Members

        public float caculateBound()
        {
            float Totalbound;
            Totalbound = inCome * bounds_percent;
            Console.WriteLine("Tien thuong cau thu : " + Totalbound);
            return Totalbound;
        }

        #endregion
    }
}
