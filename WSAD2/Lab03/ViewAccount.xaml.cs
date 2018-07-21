using Lab03.Models;
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

namespace Lab03
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewAccount : Page
    {
        public ViewAccount()
        {
            this.InitializeComponent();

            gvAccounts.ItemsSource = Models.AccountDB.accountList;
        }

        private void gvAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Models.Account account = gvAccounts.SelectedItem as Models.Account;
            ObservableCollection<Account> newList = new ObservableCollection<Account>();
            newList.Add(account);
            gvDetails.ItemsSource = newList;
        }
    }
}