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

namespace WSAD_Exam
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewEmployee : Page
    {
        public AddNewEmployee()
        {
            this.InitializeComponent();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                await new MessageDialog("Id is required").ShowAsync();
                txtID.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtFullName.Text))
            {
                await new MessageDialog("Full name is required").ShowAsync();
                txtFullName.Focus(FocusState.Keyboard);
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
            else
            {
                Employee emp = new Employee
            {
                EmployeeID = txtID.Text,
                FullName = txtFullName.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text
            };
                EmployeeData.EmployeeList.Add(emp);
                lbMess.Text = "Save completed.";
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }
    }
}