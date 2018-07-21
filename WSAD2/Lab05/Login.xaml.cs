using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab05
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //var userAccount = from i
            //    in Models.UserContext.uList
            //                  where i.UserName.Equals(txtUserName.Text)
            //                  select i;
            var userAccount = Models.UserContext.uList.SingleOrDefault(u => u.UserName.Equals(txtUserName.Text));

            if (userAccount == null)
            {
                lbMessages.Text = "User not found!";
            }
            else
            {
                if (userAccount.Password.Equals(Models.SecurityPassword.EncryptDecryptPassword(txtPassword.Password)))
                {
                    //if (userAccount.IsAdmin.Equals(true))
                    //{
                    //    Frame.Navigate(typeof(ViewDetails));
                    //}
                    //else
                    //{
                    Frame.Navigate(typeof(ViewDetails), userAccount);
                    //}
                }
                else
                {
                    lbMessages.Text = "Invalid Password!";
                }
            }
        }
    }
}