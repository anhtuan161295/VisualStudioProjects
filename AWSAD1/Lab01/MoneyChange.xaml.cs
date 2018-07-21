using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MoneyChange : Page
    {
        public MoneyChange()
        {
            this.InitializeComponent();

            tblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void ChangeLanguage()
        {
            var rc = new ResourceContext();
            string choice = (bool)rdEnglish.IsChecked ? "en" : "vi";
            if (choice == "en")
            {
                var culture = new CultureInfo("en-US");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("enResources");
                tblAmount.Text = rs.GetValue("tblAmount", rc).ValueAsString;
                tblResource.Text = rs.GetValue("tblResource", rc).ValueAsString;
                tblResult.Text = rs.GetValue("tblResult", rc).ValueAsString;
                tblTarget.Text = rs.GetValue("tblTarget", rc).ValueAsString;
                btnConvert.Content = rs.GetValue("btnConvert", rc).ValueAsString;
                tblExchange.Text = rs.GetValue("tblExchange", rc).ValueAsString;
                img.Source = new BitmapImage(new Uri(rs.GetValue("img", rc).ValueAsString)); ;
                tblDay.Text = rs.GetValue("tblDay", rc).ValueAsString;

                //Xác định ngôn ngữ chính dựa trên culture (mã ngôn ngữ-mã quốc gia)
                //Giờ datetime tùy theo quốc gia nên phải chọn ngôn ngữ chính trước.
                //Hoặc set datetime ngoài if else cho đơn giản
                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
                tblDate.Text = new DateTimeFormatter("longdate").Format(DateTimeOffset.Now);
            }
            if (choice == "vi")
            {
                var culture = new CultureInfo("vi-VN");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("viResources");
                tblAmount.Text = rs.GetValue("tblAmount", rc).ValueAsString;
                tblResource.Text = rs.GetValue("tblResource", rc).ValueAsString;
                tblResult.Text = rs.GetValue("tblResult", rc).ValueAsString;
                tblTarget.Text = rs.GetValue("tblTarget", rc).ValueAsString;
                btnConvert.Content = rs.GetValue("btnConvert", rc).ValueAsString;
                tblExchange.Text = rs.GetValue("tblExchange", rc).ValueAsString;
                img.Source = new BitmapImage(new Uri(rs.GetValue("img", rc).ValueAsString)); ;
                tblDay.Text = rs.GetValue("tblDay", rc).ValueAsString;

                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
                tblDate.Text = new DateTimeFormatter("longdate").Format(DateTimeOffset.Now);
            }
            //tblDate.Text = new DateTimeFormatter("longdate").Format(DateTimeOffset.Now);
        }

        private void rdEnglish_Checked(object sender, RoutedEventArgs e)
        {
            ChangeLanguage();
        }

        private void rdVietnamese_Checked(object sender, RoutedEventArgs e)
        {
            ChangeLanguage();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            if (string.IsNullOrEmpty(txtAmount.Text) || double.TryParse(txtAmount.Text, out temp) == false)
            {
                new MessageDialog("Amount is required").ShowAsync();
            }
            else
            {
                double amount = temp;
                double result = 0;

                string resource = cbResource.SelectedItem.ToString();

                string target = cbTarget.SelectedItem.ToString();
                switch (resource)
                {
                    case "USD":
                        switch (target)
                        {
                            case "USD":
                                result = amount;
                                break;

                            case "EUR":
                                result = amount * 0.902494495;
                                break;

                            case "VND":
                                result = amount * 22222.2222;
                                break;
                        }
                        break;

                    case "EUR":
                        switch (target)
                        {
                            case "USD":
                                result = amount * 1.10804;
                                break;

                            case "EUR":
                                result = amount;
                                break;

                            case "VND":
                                result = amount * 24623.1111;
                                break;
                        }
                        break;

                    case "VND":
                        switch (target)
                        {
                            case "USD":
                                result = amount * 0.0000445434;
                                break;

                            case "EUR":
                                result = amount * 0.000040525;
                                break;

                            case "VND":
                                result = amount;
                                break;
                        }
                        break;
                }
                txtResult.Text = result.ToString();
            }
        }
    }
}