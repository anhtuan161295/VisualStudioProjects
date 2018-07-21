using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AS03_04
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewCar : Page
    {
        private Car car;

        public ViewCar()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), car);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            car = e.Parameter as Car;
            if (car == null)
            {
                cvsNoCar.Visibility = Visibility.Visible;
                cvsCarInfo.Visibility = Visibility.Collapsed;
            }
            else
            {
                cvsNoCar.Visibility = Visibility.Collapsed;
                cvsCarInfo.Visibility = Visibility.Visible;
                txtMade.Text = car.Made;
                txtModel.Text = car.Model;
                txtAddon.Text = car.Addon;
                txtYearOfReg.Text = car.YearOfReg;
                txtRentPerDay.Text = car.RentPerDay;
            }
        }
    }
}