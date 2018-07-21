using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01.Models
{
    class BookContext
    {
        public static ObservableCollection<Book> bList = new ObservableCollection<Book>
        {
            new Book {ISBN = "ISBN101", Title = "Windows Phone 8", Author = "Microsoft", Price = 21, ImgName = "h1.png"},
            new Book {ISBN = "ISBN102", Title = "Windows Phone 9", Author = "Microsoft", Price = 22, ImgName = "h2.png"},
            new Book {ISBN = "ISBN103", Title = "Windows Phone 10", Author = "Microsoft", Price = 23, ImgName = "h3.png"},
            new Book {ISBN = "ISBN104", Title = "Windows Phone 11", Author = "Microsoft", Price = 24, ImgName = "h4.png"}
        };
    }
}