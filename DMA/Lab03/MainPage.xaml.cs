using Coding4Fun.Toolkit.Controls;
using Lab03.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Lab03
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

        private void toastMessage(string msg)
        {
            var toast = new ToastPrompt()
            {
                Title = "Toast Message",
                TextOrientation = System.Windows.Controls.Orientation.Horizontal,
                Message = msg,
                ImageSource = new BitmapImage(new Uri("Images/h1.png", UriKind.RelativeOrAbsolute))
            };
            toast.Show();
        }

        private ShellTile checkTile(string tile)
        {
            var result = ShellTile.ActiveTiles.SingleOrDefault(u => u.NavigationUri.ToString().EndsWith(tile));
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        private void btnFlip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkTile("flipTile") == null)
                {
                    FlipTileData flipTileData = new FlipTileData()
                    {
                        Title = "Sai Gon Xua",
                        Count = DateTime.Now.Second,
                        BackTitle = "Sai Gon Nay",
                        BackgroundImage = new Uri("Images/h1.png", UriKind.Relative),
                        BackBackgroundImage = new Uri("Images/h2.png", UriKind.Relative)
                    };
                    ShellTile.Create(new Uri("/MainPage.xaml?flipTile", UriKind.RelativeOrAbsolute), flipTileData, true);
                }
                else
                {
                    //MessageBox.Show("FlipTile Existing!");
                    toastMessage("FlipTile Existing");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIconic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkTile("iconicTile") == null)
                {
                    IconicTileData flipTileData = new IconicTileData()
                    {
                        Title = "VietNam",
                        Count = DateTime.Now.Second,
                        IconImage = new Uri("Images/h1.png", UriKind.RelativeOrAbsolute),
                        WideContent1 = "Viet Nam",
                        WideContent2 = "Sai Gon"
                    };
                    ShellTile.Create(new Uri("/MainPage.xaml?iconicTile", UriKind.RelativeOrAbsolute), flipTileData, true);
                }
                else
                {
                    MessageBox.Show("IconicTile Existing!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCycle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkTile("cycleTile") == null)
                {
                    CycleTileData flipTileData = new CycleTileData()
                    {
                        Title = "VietNam",
                        Count = DateTime.Now.Second,
                        SmallBackgroundImage = new Uri("Images/h1.png", UriKind.RelativeOrAbsolute),
                        CycleImages = new Uri[]
                        {
                            new Uri("Images/h1.png", UriKind.RelativeOrAbsolute),
                            new Uri("Images/h2.png", UriKind.RelativeOrAbsolute),
                            new Uri("Images/h3.png", UriKind.RelativeOrAbsolute),
                            new Uri("Images/h4.png", UriKind.RelativeOrAbsolute),
                            new Uri("Images/h5.png", UriKind.RelativeOrAbsolute),
                            new Uri("Images/h6.png", UriKind.RelativeOrAbsolute)
                        }
                    };
                    ShellTile.Create(new Uri("/MainPage.xaml?cycleTile", UriKind.RelativeOrAbsolute), flipTileData, true);
                }
                else
                {
                    MessageBox.Show("CycleTile Existing!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Alarm alarm;

        private void img_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            alarm = new Alarm(new Guid().ToString())
            {
                BeginTime = DateTime.Now.AddSeconds(1),
                ExpirationTime = DateTime.Now.AddSeconds(100),
                Content = "Den gio lam Assignment 4!",
                //Title = "Assignment 4",
                //RecurrenceType = RecurrenceInterval.Daily
            };

            ScheduledActionService.Add(alarm);
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