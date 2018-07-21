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
    public sealed partial class UCViewItem : UserControl
    {
        public UCViewItem()
        {
            this.InitializeComponent();
            gvItems.ItemsSource = Models.ItemContext.iList;
            changeLanguage();
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
                lblTotal.Text = rs.GetValue("lblTotal", rc).ValueAsString;

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
                lblTotal.Text = rs.GetValue("lblTotal", rc).ValueAsString;

                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            }
        }
    }
}