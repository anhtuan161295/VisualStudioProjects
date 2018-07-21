using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Lab02
{
    public partial class WebBrowseTest : PhoneApplicationPage
    {
        public WebBrowseTest()
        {
            InitializeComponent();
        }

        private void txtURI_LostFocus(object sender, RoutedEventArgs e)
        {
            txtWebBrowse.Navigate(new Uri(txtURI.Text, UriKind.Absolute));
        }
    }
}