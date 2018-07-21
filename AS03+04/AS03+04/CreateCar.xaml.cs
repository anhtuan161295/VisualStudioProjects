using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class CreateCar : Page
    {
        private Car c;
        int temp;

        public CreateCar()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), c);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            c = e.Parameter as Car;
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMade.Text))
            {
                await new MessageDialog("Made is required").ShowAsync();
                txtMade.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtModel.Text))
            {
                await new MessageDialog("Model is required").ShowAsync();
                txtModel.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtAddon.Text))
            {
                await new MessageDialog("Addon is required").ShowAsync();
                txtAddon.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtYearOfReg.Text))
            {
                await new MessageDialog("Year of Registration is required").ShowAsync();
                txtYearOfReg.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtRentPerDay.Text))
            {
                await new MessageDialog("Rent price per day is required").ShowAsync();
                txtRentPerDay.Focus(FocusState.Keyboard);
                return;
            }

            if (int.TryParse(txtRentPerDay.Text, out temp) == false || temp <= 0)
            {
                await new MessageDialog("Rent price per day > 0 only").ShowAsync();
                txtRentPerDay.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                await new MessageDialog("Create success").ShowAsync();
                c = new Car();
                c.Made = txtMade.Text;
                c.Model = txtModel.Text;
                c.Addon = txtAddon.Text;
                c.YearOfReg = txtYearOfReg.Text;
                c.RentPerDay = temp.ToString();

                Frame.Navigate(typeof(MainPage), c);
            }
        }
    }
}