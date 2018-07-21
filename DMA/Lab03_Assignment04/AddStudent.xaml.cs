using Coding4Fun.Toolkit.Controls;
using Lab03_Assignment04.Models;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Lab03_Assignment04
{
    public partial class AddStudent : PhoneApplicationPage
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void toastMessage(string msg)
        {
            ToastPrompt toast = new ToastPrompt()
            {
                Title = "Toast Message",
                Message = msg,
                TextOrientation = System.Windows.Controls.Orientation.Horizontal,
                //FontSize = 24,
                ImageSource = new BitmapImage(new Uri("Images/warning.png", UriKind.RelativeOrAbsolute)),
                ImageHeight = 30,
                ImageWidth = 30,
                Stretch = Stretch.Uniform,
            };
            toast.MillisecondsUntilHidden = 3000;

            toast.Show();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                toastMessage("Id is required!");
                txtID.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtName.Text))
            {
                toastMessage("Name is required!");
                txtName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                toastMessage("Address is required!");
                txtAddress.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtDateOfBirth.Text))
            {
                toastMessage("Date of Birth is required!");
                txtDateOfBirth.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                toastMessage("Phone is required!");
                txtPhone.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                toastMessage("Email is required!");
                txtEmail.Focus();
                return;
            }
            else if (Regex.IsMatch(txtID.Text, "^\\d+$") == false)
            {
                toastMessage("ID must be a number!");
                txtID.Focus();
                return;
            }
            else if (txtName.Text.Length < 3)
            {
                toastMessage("Name length must larger than 3 characters!");
                txtName.Focus();
                return;
            }
            else if (txtAddress.Text.Length < 2 || txtAddress.Text.Length > 30)
            {
                toastMessage("Address length must larger than 3 characters or lower than 30 characters!");
                txtName.Focus();
                return;
            }
            else if (Regex.IsMatch(txtPhone.Text, "(\\+84|0)\\d{9,10}") == false)
            {
                toastMessage("Phone must be a valid number!");
                txtPhone.Focus();
                return;
            }
            else if (Regex.IsMatch(txtEmail.Text, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?") == false)
            {
                toastMessage("Email must be a valid format!");
                txtEmail.Focus();
                return;
            }
            else
            {
                Models.Student student = new Student()
                {
                    Id = int.Parse(txtID.Text),
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    DateOfBirth = txtDateOfBirth.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text
                };
                Models.StudentContext.sList.Add(student);
                toastMessage("Add student completed!");
            }
        }
    }
}