using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Lab03.Models
{
    class Employee
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Passcode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public string imgPath { get; set; }

        public ImageSource img
        {
            get { return new BitmapImage(new Uri("ms-appx:///Images/" + imgPath)); }
        }
    }
}