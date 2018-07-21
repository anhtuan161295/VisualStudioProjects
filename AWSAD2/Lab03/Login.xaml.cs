using Lab03.Models;
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

namespace Lab03
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var employee = Models.EmployeeContext.eList.SingleOrDefault(u => u.UserName.Equals(txtName.Text) && CryptographyLibrary.Decrypt(u.Passcode).Equals(txtPass.Password));
            //string passDecryption = CryptographyLibrary.Decrypt(employee.Passcode);
            //if (passDecryption == "123")
            //{
            //    new MessageDialog("Equal").ShowAsync();
            //}
            //else
            //{
            //    new MessageDialog("Not Equal").ShowAsync();
            //}
            if (employee == null)
            {
                txtMessage.Text = "Employee not found!";
            }
            else
            {
                if (employee.IsAdmin == true)
                {
                    Frame.Navigate(typeof(ManageEmployee), employee);
                }
                else
                {
                    Frame.Navigate(typeof(ViewDetails), employee);
                }
            }
        }
    }
}