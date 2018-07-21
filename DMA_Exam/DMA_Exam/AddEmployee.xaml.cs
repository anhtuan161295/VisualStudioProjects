using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DMA_Exam
{
    public partial class AddEmployee : PhoneApplicationPage
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //All fields not blank
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Id is required!");
                txtId.Focus();
            }
            else if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("First name is required!");
                txtFirstName.Focus();
            }
            else if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Last name is required!");
                txtLastName.Focus();
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Address is required!");
                txtAddress.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email is required!");
                txtEmail.Focus();
            }
            //First name length 3-20 chars
            else if (txtFirstName.Text.Length < 3 || txtFirstName.Text.Length > 20)
            {
                MessageBox.Show("First name length 3-20 chars!");
                txtFirstName.Focus();
            }
            else
            {
                try
                {
                    if (!isf.DirectoryExists("MyFolder"))
                    {
                        isf.CreateDirectory("MyFolder");
                    }
                    else
                    {
                        //do nothing
                    }
                    using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(@"MyFolder\EmployeeDetails.txt", FileMode.Create, isf))
                    {
                        StreamWriter sw = new StreamWriter(isfs);
                        sw.WriteLine(txtId.Text);
                        sw.WriteLine(txtFirstName.Text);
                        sw.WriteLine(txtLastName.Text);
                        sw.WriteLine(txtAddress.Text);
                        sw.WriteLine(txtEmail.Text);

                        sw.Flush();
                        sw.Close();
                    }
                    MessageBox.Show("Save completed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isf.DirectoryExists("MyFolder"))
                {
                    MessageBox.Show("File not found!");
                }
                else
                {
                    using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(@"MyFolder\EmployeeDetails.txt", FileMode.Open, isf))
                    {
                        StreamReader sr = new StreamReader(isfs);

                        MessageBox.Show(
                            "Employee ID: " + sr.ReadLine() + "\n" +
                            "Full name: " + sr.ReadLine() + " " + sr.ReadLine() + "\n" +
                            "Address: " + sr.ReadLine() + "\n" +
                            "Email: " + sr.ReadLine() + "\n"
                            );
                        sr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}