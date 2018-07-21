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

namespace Ass567
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateCustomer : Page
    {
        public CreateCustomer()
        {
            this.InitializeComponent();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            bool checkAdmin;
            if (radioAdmin.IsChecked == true)
            {
                checkAdmin = true;
            }
            else
            {
                checkAdmin = false;
            }
            Customer customer = new Customer
            {
                Fullname = txtFullname.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Password,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                IsAdmin = checkAdmin
            };
            CustomerDB.customerList.Add(customer);
            await new MessageDialog("Add customer completed").ShowAsync();
        }
    }
}