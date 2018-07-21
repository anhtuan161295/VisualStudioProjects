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
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private async void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                await new MessageDialog("Username is required").ShowAsync();
                txtUsername.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtPassword.Password))
            {
                await new MessageDialog("Password is required").ShowAsync();
                txtPassword.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                foreach (var item in CustomerDB.customerList)
                {
                    if (item.Username.Equals(txtUsername.Text) & item.Password.Equals(txtPassword.Password))
                    {
                        await new MessageDialog("Login success").ShowAsync();
                        Frame.Navigate(typeof(ViewCustomer), item);
                    }
                }
            }
        }
    }
}