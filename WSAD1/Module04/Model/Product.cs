using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module04.Model
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public double Total
        {
            get { return Quantity * Price; }
        }

        public override string ToString()
        {
            return Id + "\t" + Name + "\t" + Price + "\t" + Quantity;
        }
    }
}