using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Ass567
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewCustomer : Page
    {
        public ViewCustomer()
        {
            this.InitializeComponent();
        }

        private void loadUsers()
        {
            gvListUser.ItemsSource = CustomerDB.customerList;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Customer customer = e.Parameter as Customer;
            ObservableCollection<Customer> newList = new ObservableCollection<Customer> { customer };
            if (customer.IsAdmin == true)
            {
                gvListUser.Visibility = Visibility.Visible;
                loadUsers();
            }
            else
            {
                gvListUser.Visibility = Visibility.Collapsed;
                gvCustomerDetails.ItemsSource = newList;
            }
        }

        private void gvListUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer customer = gvListUser.SelectedItem as Customer;
            ObservableCollection<Customer> newList = new ObservableCollection<Customer> { customer };
            gvCustomerDetails.ItemsSource = newList;
        }
    }
}