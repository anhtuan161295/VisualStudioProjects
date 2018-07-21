using Lab04_Assignment05.Models;
using Lab04_Assignment05.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Lab04_Assignment05
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

        Models.GameContext db = new GameContext("isostore:/game.sdf");

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
            else
            {
                // do nothing
            }
            try
            {
                Models.Game game = new Game()
                {
                    Id = int.Parse(txtId.Text),
                    Title = txtTitle.Text,
                    YearOfRelease = DateTime.Parse(txtYear.Text),
                    Price = double.Parse(txtPrice.Text)
                };
                db.Games.InsertOnSubmit(game);
                db.SubmitChanges();
                MessageBox.Show("Add game completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            var res = from g in db.Games select g;
            listBox.ItemsSource = res;
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