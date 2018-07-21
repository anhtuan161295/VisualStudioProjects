using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS07_08
{
    class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public string Describe { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public double Total
        {
            get { return Price * Quantity; }
        }

        public override string ToString()
        {
            string s = "Id: " + Id + "\r\n" +
                "Name: " + Name + "\r\n" +
                "Manufacture: " + Manufacture + "\r\n" +
                "Describe: " + Describe + "\r\n" +
                "Price: " + Price + "\r\n" +
                "Quantity: " + Quantity + "\r\n" +
                "Total: " + Price * Quantity + "\r\n";
            return s;
        }
    }

    class ComputerData
    {
        public static ObservableCollection<Computer> cList = new ObservableCollection<Computer>();
    }
}