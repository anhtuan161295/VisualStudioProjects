using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Module05.Model
{
    class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }

        public ImageSource Img
        {
            get { return new BitmapImage(new Uri("ms-appdata:///local/Images/" + Photo)); }
        }
    }

    class BookContext
    {
        public static ObservableCollection<Book> bList = new ObservableCollection<Book>();
    }
}