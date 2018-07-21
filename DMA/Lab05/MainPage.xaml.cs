using Lab05.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Lab05
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmailTask.xaml", UriKind.Relative));
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            ConnectionSettingsTask cst = new ConnectionSettingsTask()
            {
                ConnectionSettingsType = ConnectionSettingsType.Bluetooth
            };
            cst.Show();
        }

        private void btnMap_Click(object sender, RoutedEventArgs e)
        {
            MapsDirectionsTask mdt = new MapsDirectionsTask()
            {
                Start = new LabeledMapLocation("Ho Chi Minh, Viet Nam", null),
                End = new LabeledMapLocation("Ha Noi, Viet Nam", null)
            };
            mdt.Show();
        }

        private void btnCall_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask pct = new PhoneCallTask()
            {
                DisplayName = "VinhAP",
                PhoneNumber = "01233750483"
            };
            pct.Show();
        }

        private void btnSearchTask_Click(object sender, RoutedEventArgs e)
        {
            SearchTask st = new SearchTask()
            {
                SearchQuery = "Banana"
            };
            st.Show();
        }

        private void address_Completed(object sender, AddressResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                MessageBox.Show("\nName: " + e.DisplayName + "\nAddress: " + e.Address);
            }
        }

        private void btnAddress_Click(object sender, RoutedEventArgs e)
        {
            AddressChooserTask act = new AddressChooserTask();
            act.Completed += address_Completed;
            act.Show();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}