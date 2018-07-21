using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Globalization.DateTimeFormatting;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AWSAD_Exam
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            gvCustomers.ItemsSource = CustomerData.CustomerList;
            cbLanguage.SelectedIndex = 0;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                await new MessageDialog("ID is required").ShowAsync();
                txtID.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtName.Text))
            {
                await new MessageDialog("Name is required").ShowAsync();
                txtName.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                await new MessageDialog("Address is required").ShowAsync();
                txtAddress.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                await new MessageDialog("Phone is required").ShowAsync();
                txtPhone.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                Customer cus = new Customer
                {
                    CustomerID = txtID.Text,
                    CustomerName = txtName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text
                };
                CustomerData.CustomerList.Add(cus);
                await new MessageDialog("Add customer completed").ShowAsync();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rc = new ResourceContext();

            string choice = (cbLanguage.SelectedIndex == 0) ? "en" : "vi";
            if (choice == "en")
            {
                var culture = new CultureInfo("en-US");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("enResources");
                txtTitle.Text = rs.GetValue("txtTitle", rc).ValueAsString;
                lblID.Text = rs.GetValue("lblID", rc).ValueAsString;
                lblName.Text = rs.GetValue("lblName", rc).ValueAsString;
                lblAddress.Text = rs.GetValue("lblAddress", rc).ValueAsString;
                lblPhone.Text = rs.GetValue("lblPhone", rc).ValueAsString;
                btnSave.Content = rs.GetValue("btnSave", rc).ValueAsString;
                btnExit.Content = rs.GetValue("btnExit", rc).ValueAsString;
                lblSelectLanguage.Text = rs.GetValue("lblSelectLanguage", rc).ValueAsString;
                lblDate.Text = rs.GetValue("lblDate", rc).ValueAsString;

                //Xác định ngôn ngữ chính dựa trên culture (mã ngôn ngữ-mã quốc gia)
                //Giờ datetime tùy theo quốc gia nên phải chọn ngôn ngữ chính trước.
                //Hoặc set datetime ngoài if else cho đơn giản
                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            }

            if (choice == "vi")
            {
                var culture = new CultureInfo("vi-VN");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("viResources");
                txtTitle.Text = rs.GetValue("txtTitle", rc).ValueAsString;
                lblID.Text = rs.GetValue("lblID", rc).ValueAsString;
                lblName.Text = rs.GetValue("lblName", rc).ValueAsString;
                lblAddress.Text = rs.GetValue("lblAddress", rc).ValueAsString;
                lblPhone.Text = rs.GetValue("lblPhone", rc).ValueAsString;
                btnSave.Content = rs.GetValue("btnSave", rc).ValueAsString;
                btnExit.Content = rs.GetValue("btnExit", rc).ValueAsString;
                lblSelectLanguage.Text = rs.GetValue("lblSelectLanguage", rc).ValueAsString;
                lblDate.Text = rs.GetValue("lblDate", rc).ValueAsString;

                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            }
            txtDay.Text = new DateTimeFormatter("shortdate longtime").Format(DateTimeOffset.Now);
        }

        private void gvCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var model = gvCustomers.SelectedItem as Customer;
            if (model != null)
            {
                txtID.Text = model.CustomerID;
                txtName.Text = model.CustomerName;
                txtAddress.Text = model.Address;
                txtPhone.Text = model.Phone;
            }
        }
    }
}