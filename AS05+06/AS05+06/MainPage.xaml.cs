using System;
using System.Linq;
using AS05_06.Model;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AS05_06
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            gvCar.ItemsSource = CarDataSource.list;
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var car = CarDataSource.list.SingleOrDefault(c => c.Make.Equals(txtMake.Text));
            if (car == null)
            {
                await new MessageDialog("Car is not found").ShowAsync();
            }
            else
            {
                car.Model = txtModel.Text;
                car.YearOfReg = txtYear.Text;
                car.Addon = txtAddon.Text;
                car.RentPerDay = double.Parse(txtRent.Text);
                await new MessageDialog("Update car completed").ShowAsync();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var car = CarDataSource.list.SingleOrDefault(c => c.Make.Equals(txtMake.Text));
            if (car == null)
            {
                await new MessageDialog("Car is not found").ShowAsync();
            }
            else
            {
                CarDataSource.list.Remove(car);
                await new MessageDialog("Delete car completed").ShowAsync();
            }
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var car = CarDataSource.list.SingleOrDefault(c => c.Make.Equals(txtMake.Text));
            if (car == null)
            {
                Car car1 = new Car()
             {
                 Make = txtMake.Text,
                 Model = txtModel.Text,
                 YearOfReg = txtYear.Text,
                 Addon = txtAddon.Text,
                 RentPerDay = double.Parse(txtRent.Text)
             };

                CarDataSource.list.Add(car1);
                await new MessageDialog("Create car completed").ShowAsync();
            }
            else
            {
                await new MessageDialog("Car is found, please enter a new make").ShowAsync();
            }
        }
    }
}