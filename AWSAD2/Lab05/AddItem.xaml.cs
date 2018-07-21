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
    public sealed partial class AddItem : Page
    {
        public AddItem()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var rc = new ResourceContext();
            //string choice = e.Parameter as string;
            if (MainPage.choice == "en")
            {
                var culture = new CultureInfo("en-US");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("enResources");
                tblTitleAdd.Text = rs.GetValue("tblTitleAdd", rc).ValueAsString;
                btnBack.Content = rs.GetValue("btnBack", rc).ValueAsString;

                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            }
            else if (MainPage.choice == "vi")
            {
                var culture = new CultureInfo("vi-VN");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("viResources");
                tblTitleAdd.Text = rs.GetValue("tblTitleAdd", rc).ValueAsString;
                btnBack.Content = rs.GetValue("btnBack", rc).ValueAsString;

                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            }
        }
    }
}