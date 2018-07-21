using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Module02.Model;
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

namespace Module02
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateStudent : Page
    {
        public CreateStudent()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                await new MessageDialog("Name can not be blank").ShowAsync();
                txtId.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtName.Text))
            {
                await new MessageDialog("Name can not be blank").ShowAsync();
                txtName.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                await new MessageDialog("Name can not be blank").ShowAsync();
                txtAddress.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                await new MessageDialog("Name can not be blank").ShowAsync();
                txtEmail.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                await new MessageDialog("Create success").ShowAsync();
                Student s = new Student();
                s.Id = txtId.Text;
                s.Name = txtName.Text;
                s.Address = txtAddress.Text;
                s.Email = txtEmail.Text;
                //Model.Student student = new Student
                //{
                //    Id = txtId.Text,
                //    Name = txtName.Text,
                //    Address = txtAddress.Text,
                //    Email = txtEmail.Text
                //};

                Frame.Navigate(typeof(Result), s);
            }
        }
    }
}