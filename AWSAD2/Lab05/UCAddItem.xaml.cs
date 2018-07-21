using Lab05.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Lab05
{
    public sealed partial class UCAddItem : UserControl
    {
        public UCAddItem()
        {
            this.InitializeComponent();
            changeLanguage();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                await new MessageDialog("Id is required").ShowAsync();
                txtId.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtName.Text))
            {
                await new MessageDialog("Name is required").ShowAsync();
                txtName.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                await new MessageDialog("Price is required").ShowAsync();
                txtPrice.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                await new MessageDialog("Quantity is required").ShowAsync();
                txtQuantity.Focus(FocusState.Keyboard);
                return;
            }
            else if (Regex.IsMatch(txtId.Text, @"\d+") == false)
            {
                await new MessageDialog("Id invalid, must be a number").ShowAsync();
                txtId.Focus(FocusState.Keyboard);
                return;
            }
            else if (Regex.IsMatch(txtPrice.Text, @"\d+") == false)
            {
                await new MessageDialog("Price invalid, must be a number").ShowAsync();
                txtPrice.Focus(FocusState.Keyboard);
                return;
            }
            else if (Regex.IsMatch(txtQuantity.Text, @"\d+") == false)
            {
                await new MessageDialog("Quantity invalid, must be a number").ShowAsync();
                txtQuantity.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                var item = new Models.Item
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtName.Text,
                    Price = double.Parse(txtPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text)
                };
                Models.ItemContext.iList.Add(item);
                await new MessageDialog("Add item completed").ShowAsync();
            }
        }

        private void changeLanguage()
        {
            var rc = new ResourceContext();
            //string choice = e.Parameter as string;
            if (MainPage.choice == "en")
            {
                var culture = new CultureInfo("en-US");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("enResources");
                lblId.Text = rs.GetValue("lblId", rc).ValueAsString;
                lblName.Text = rs.GetValue("lblName", rc).ValueAsString;
                lblPrice.Text = rs.GetValue("lblPrice", rc).ValueAsString;
                lblQuantity.Text = rs.GetValue("lblQuantity", rc).ValueAsString;
                btnCreate.Content = rs.GetValue("btnCreate", rc).ValueAsString;

                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            }
            else if (MainPage.choice == "vi")
            {
                var culture = new CultureInfo("vi-VN");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("viResources");
                lblId.Text = rs.GetValue("lblId", rc).ValueAsString;
                lblName.Text = rs.GetValue("lblName", rc).ValueAsString;
                lblPrice.Text = rs.GetValue("lblPrice", rc).ValueAsString;
                lblQuantity.Text = rs.GetValue("lblQuantity", rc).ValueAsString;
                btnCreate.Content = rs.GetValue("btnCreate", rc).ValueAsString;

                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            }
        }
    }
}