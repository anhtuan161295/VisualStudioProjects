using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_07_Sale
    {
        int MedicineCode, QuantitySold, PlannedSale, ActualSale;
        string region;
        public Assignment_07_Sale()
        {

        }
        public Assignment_07_Sale(int medcode, int quantity, int plan, int actual, string region)
        {
            this.MedicineCode = medcode;
            this.QuantitySold = quantity;
            this.PlannedSale = plan;
            this.ActualSale = actual;
            this.region = region;
        }

        public string Region
        {
            get
            {
                return region;
            }

            set
            {
                region = value;
            }
        }

        public int PlannedSale1
        {
            get
            {
                return PlannedSale;
            }

            set
            {
                PlannedSale = value;
            }
        }

        public int QuantitySold1
        {
            get
            {
                return QuantitySold;
            }

            set
            {
                QuantitySold = value;
            }
        }

        public int ActualSale1
        {
            get
            {
                return ActualSale;
            }

            set
            {
                ActualSale = value;
            }
        }

        public int MedicineCode1
        {
            get
            {
                return MedicineCode;
            }

            set
            {
                MedicineCode = value;
            }
        }

        public string getstring()
        {
            return "\nMedicine Code:" + MedicineCode + "\nQuantity Sold:" + QuantitySold + "\nPlanned Sale" + PlannedSale +
                "\nActual Sale:" + ActualSale + "\nRegion:" + region;
        }
    }
}
