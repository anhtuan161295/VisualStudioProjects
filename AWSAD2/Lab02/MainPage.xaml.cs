using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab02
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

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateGame));
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewGame));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Exit();
        }

        private async void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            //Khai bao doi tuong LicenseInformation de lay thong tin License
            LicenseInformation l = CurrentAppSimulator.LicenseInformation;
            //Neu ung dung chua active
            if (l.IsActive == false)
            {
                //Lay thong tin ten san pham va phi su dung
                ListingInformation listing = await CurrentAppSimulator.LoadListingInformationAsync();
                var pro = listing.ProductListings["P001"];
                txtDetails.Text = "You can buy " + pro.Name + " for: " + pro.FormattedPrice + ".";
            }
        }

        private async Task LoadLicenseInfo()
        {
            //Lay thu muc Data trong ung dung (thu muc may chi doc)
            StorageFolder proxyDataFolder = await Package.Current.InstalledLocation.GetFolderAsync("Data");
            //Doc thong tin trong tap tin CurrentAppSimulator
            StorageFile proxyFile = await proxyDataFolder.GetFileAsync("StoreLicense.xml");
            //Nap du lieu vao CurrentAppSimulator
            await CurrentAppSimulator.ReloadSimulatorAsync(proxyFile);
        }

        private async void GetLicenseInfo()
        {
            var l = CurrentAppSimulator.LicenseInformation;
            //Neu ung dung da duoc active
            if (l.IsActive)
            {
                if (l.IsTrial)
                {
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        txtDetails.Text = "License Status: Trial License.";
                        var r = (l.ExpirationDate - DateTime.Now).Days;
                        txtDetails.Text += System.Environment.NewLine +
                                      String.Format("Remaining days: {1}", l.ExpirationDate, r);
                    });
                }
                //Neu ung dung la phien ban chinh thuc
                else
                {
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        txtDetails.Text = "License Status: Full License. ";
                        txtDetails.Text += "No expiry";
                    });
                }
            }
            else
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    txtDetails.Text = "License Status: License expired. Purchase the app!";
                });
            }
        }//and MainPage class

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.LoadLicenseInfo();
            GetLicenseInfo();
        }
    }
}