using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ASM_Ngay_1.Model
{
    class Category
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public ImageSource Photo
        {
            get { return new BitmapImage(new Uri("ms-appx:///Images/" + ImagePath)); }
        }
    }

    class CategoryData
    {
        public static ObservableCollection<Category> CategoryList = new ObservableCollection<Category>
        {
            new Category{CategoryName = "Beverages", Description = "Soft drink, coffees, teas, beers",ImagePath = "h1.png"},
            new Category{CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes",ImagePath = "h2.png"},
            new Category{CategoryName = "Confections", Description = "Desserts, candies, and sweet breads",ImagePath = "h3.png"},
            new Category{CategoryName = "Dairy Products", Description = "Cheeses",ImagePath = "h4.png"},
            new Category{CategoryName = "Grains/Cereals", Description = "Breads, crackers and pasta",ImagePath = "h5.png"},
            new Category{CategoryName = "Meat/Poultry", Description = "Prepared meats",ImagePath = "h6.png"},
            new Category{CategoryName = "Produce", Description = "Dried fruit and bean curd",ImagePath = "h7.png"},
            new Category{CategoryName = "Seafood", Description = "Seaweed and fish",ImagePath = "h8.png"},
        };
    }
}