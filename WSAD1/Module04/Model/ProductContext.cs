using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module04.Model
{
    class ProductContext
    {
        public static ObservableCollection<Product> pList = new ObservableCollection<Product>()
        {
            new Product{Id = 101,Name = "Iphone 7",Price = 900,Quantity = 10},
            new Product{Id = 102,Name = "Iphone 6",Price = 600,Quantity = 20},
            new Product{Id = 103,Name = "Iphone 7",Price = 300,Quantity = 30}
        };
    }
}