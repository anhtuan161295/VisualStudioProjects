using DMA_Exam.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DMA_Exam
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                //lbMsg.Text = "Id is required!";
                MessageBox.Show("Id is required!");
                txtId.Focus();
            }
            else if (string.IsNullOrEmpty(txtPass.Password))
            {
                //lbMsg.Text = "Password is required!";
                MessageBox.Show("Password is required!");
                txtPass.Focus();
            }
            else if (!txtId.Text.Equals("fpt") || !txtPass.Password.Equals("aptech"))
            {
                lbMsg.Text = "Login fail";
                //MessageBox.Show("User name or password is invalid!");
                //txtId.Focus();
            }
            else
            {
                MessageBox.Show("Login success");
                NavigationService.Navigate(new Uri("/AddEmployee.xaml", UriKind.Relative));
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}