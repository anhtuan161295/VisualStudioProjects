using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Lab04.Models
{
    class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; } //P{0-9,5}
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImgPath { get; set; }

        public ImageSource Photo
        {
            get
            {
                return new BitmapImage(new Uri("ms-appx:///Images/" + ImgPath));
            }
        }

        public double Total
        {
            get { return Price * Quantity; }
        }
    }

    class ProductContext
    {
        public static ObservableCollection<Product> pList = new ObservableCollection<Product>
        {
            new Product{ProductId = "P1111", ProductName = "IBM T42", Price = 350, Quantity = 5, ImgPath = "h1.png"}
        };
    }
}