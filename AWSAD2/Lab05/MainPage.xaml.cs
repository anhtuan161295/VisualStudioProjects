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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab05
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        public static string choice = "en";

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddItem), choice);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewItem), choice);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rc = new ResourceContext();
            choice = (cbLanguage.SelectedItem != null && cbLanguage.SelectedIndex == 0) ? "en" : "vi";
            if (choice == "en")
            {
                var culture = new CultureInfo("en-US");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("enResources");
                btnCreate.Content = rs.GetValue("btnCreate", rc).ValueAsString;
                btnView.Content = rs.GetValue("btnView", rc).ValueAsString;
                btnClose.Content = rs.GetValue("btnClose", rc).ValueAsString;

                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            }
            else if (choice == "vi")
            {
                var culture = new CultureInfo("vi-VN");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("viResources");
                btnCreate.Content = rs.GetValue("btnCreate", rc).ValueAsString;
                btnView.Content = rs.GetValue("btnView", rc).ValueAsString;
                btnClose.Content = rs.GetValue("btnClose", rc).ValueAsString;

                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            }
        }
    }
}