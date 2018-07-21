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

namespace Lab05_Assignment06
{
    public partial class Student : PhoneApplicationPage
    {
        public Student()
        {
            InitializeComponent();
        }

        IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Id is required!");
                txtId.Focus();
            }
            else if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name is required!");
                txtName.Focus();
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
            else if (txtAddress.Text.Length < 3 || txtAddress.Text.Length > 30)
            {
                MessageBox.Show("Address length must be 3-30 characters!");
                txtAddress.Focus();
            }
            else
            {
                try
                {
                    using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream("StudentDetail.txt", FileMode.Create, isf))
                    {
                        StreamWriter sw = new StreamWriter(isfs);
                        sw.WriteLine(txtId.Text);
                        sw.WriteLine(txtName.Text);
                        sw.WriteLine(txtAddress.Text);
                        sw.WriteLine(txtEmail.Text);
                        sw.Flush();
                        sw.Close();
                        MessageBox.Show("Add student completed");
                    }
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
                if (isf.FileExists("StudentDetail.txt") == false)
                {
                    MessageBox.Show("File not found!");
                }
                else
                {
                    using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream("StudentDetail.txt", FileMode.Open, isf))
                    {
                        StreamReader sr = new StreamReader(isfs);
                        MessageBox.Show("Id: " + sr.ReadLine() + "\n" +
                                        "Name: " + sr.ReadLine() + "\n" +
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