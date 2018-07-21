using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.Models
{
    class ItemContext
    {
        public static ObservableCollection<Item> iList = new ObservableCollection<Item>
        {
            new Item{Id = 1, Name = "C Programing", Price = 100, Quantity = 5},
            new Item{Id = 2, Name = "C++ Programing", Price = 200, Quantity = 10},
            new Item{Id = 3, Name = "C# Programing", Price = 300, Quantity = 15}
        };
    }
}