using Lab03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class ManageEmployee : Page
    {
        public ManageEmployee()
        {
            this.InitializeComponent();
            gvEmployees.ItemsSource = Models.EmployeeContext.eList;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Employee emp = e.Parameter as Employee;
            if (emp != null)
            {
                txtWelcome.Text = "Welcome to " + emp.UserName;
            }
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                await new MessageDialog("Id is required").ShowAsync();
                txtId.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtFName.Text))
            {
                await new MessageDialog("Full name is required").ShowAsync();
                txtFName.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtUName.Text))
            {
                await new MessageDialog("User name is required").ShowAsync();
                txtUName.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                await new MessageDialog("Passcode is required").ShowAsync();
                txtPass.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                await new MessageDialog("Address is required").ShowAsync();
                txtAddress.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                await new MessageDialog("Email is required").ShowAsync();
                txtEmail.Focus(FocusState.Keyboard);
                return;
            }

            {
                string passEncrypted = CryptographyLibrary.Encrypt(txtPass.Text);
                Employee emp = new Employee
                {
                    EmployeeId = txtId.Text,
                    FullName = txtFName.Text,
                    UserName = txtUName.Text,
                    Passcode = passEncrypted,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    IsAdmin = (bool)cbIsAdmin.IsChecked
                };
                EmployeeContext.eList.Add(emp);
            }
        }
    }
}