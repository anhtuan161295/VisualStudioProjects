using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Lab04
{
    public partial class StoreSetting : PhoneApplicationPage
    {
        public StoreSetting()
        {
            InitializeComponent();
        }

        IsolatedStorageSettings iss = IsolatedStorageSettings.ApplicationSettings;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!iss.Contains("title") || !iss.Contains("year") || !iss.Contains("price"))
            {
                iss.Add("title", txtTitle.Text);
                iss.Add("year", txtYear.Text);
                iss.Add("price", txtPrice.Text);
            }
            else
            {
                iss["title"] = txtTitle.Text;
                iss["year"] = txtYear.Text;
                iss["price"] = txtPrice.Text;
            }
            iss.Save();
            MessageBox.Show("Add setting completed!");
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (!iss.Contains("title") || !iss.Contains("year") || !iss.Contains("price"))
            {
                MessageBox.Show("Game not found!");
            }
            else
            {
                MessageBox.Show("Game Title: " + iss["title"] + "\n" +
                "Year: " + iss["year"] + "\n" +
                "Price: " + iss["price"]);
            }
        }
    }
}