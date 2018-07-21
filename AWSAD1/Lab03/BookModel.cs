using BookWinRT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    class BookModel
    {
        public static ObservableCollection<Book> bookList = new ObservableCollection<Book>
        {
            new Book{Id = 1, Title = "JavaScript", Author = "Microsoft", Price = 21},
            new Book{Id = 2, Title = "C Programming", Author = "Apple", Price = 22},
            new Book{Id = 3, Title = "C Sharp", Author = "Intel", Price = 23}
        };
    }
}