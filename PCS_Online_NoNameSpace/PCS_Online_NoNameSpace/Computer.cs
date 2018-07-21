using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS_Online_NoNameSpace
{
    class Computer
    {
        string id;
        float price;
        int year;

        public Computer()
        {
        }

        public Computer(string id, float price, int year)
        {
            this.id = id;
            this.price = price;
            this.year = year;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public override string ToString()
        {
            string s = "Id: " + Id + "\n"
                     + "Price: " + Price + "\n"
                     + "Year: " + Year + "\n";
            return s;
        }
    }
}