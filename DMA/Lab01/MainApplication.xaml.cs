using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Lab01
{
    public partial class MainApplication : PhoneApplicationPage
    {
        public MainApplication()
        {
            InitializeComponent();
        }

        private void imgBook_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BookManage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void imgSlider_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SliderImage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}