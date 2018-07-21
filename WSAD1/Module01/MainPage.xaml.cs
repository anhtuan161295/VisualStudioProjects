using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Module01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        DispatcherTimer dt = new DispatcherTimer();

        private void timer_Tick(object sender, object e)
        {
            flipView.Opacity += 0.1;
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                new MessageDialog("Username not blank!").ShowAsync();
                txtName.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                new MessageDialog("Password not blank!").ShowAsync();
                txtPass.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                new MessageDialog("Welcome to " + txtName.Text).ShowAsync();
                dt.Tick += timer_Tick;
                dt.Interval = TimeSpan.FromMilliseconds(120);
                dt.Start();
            }
        }

        private void btnCalculator_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Calculator), txtName.Text);
        }
    }
}