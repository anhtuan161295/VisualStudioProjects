using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Globalization.DateTimeFormatting;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            cbLanguage.SelectedIndex = 0;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            foreach (var item in BackgroundTaskRegistration.AllTasks)
            {
                item.Value.Unregister(true);
            }
            BackgroundTaskBuilder bb = new BackgroundTaskBuilder
            {
                Name = "BackgroundTask Live Tile",
                TaskEntryPoint = "BackgroundTaskTile.MyLiveTile"
            };
            bb.SetTrigger(new SystemTrigger(SystemTriggerType.NetworkStateChange, false));
            bb.Register();
        }

        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeLanguage();
        }

        private void ChangeLanguage()
        {
            var rc = new ResourceContext();

            string choice = (cbLanguage.SelectedIndex == 0) ? "en" : "vi";
            if (choice == "en")
            {
                var culture = new CultureInfo("en-US");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("enResources");
                lblPageTitle.Text = rs.GetValue("lblPageTitle", rc).ValueAsString;
                lblTitle.Text = rs.GetValue("lblTitle", rc).ValueAsString;
                lblGenre.Text = rs.GetValue("lblGenre", rc).ValueAsString;
                lblYear.Text = rs.GetValue("lblYear", rc).ValueAsString;
                lblPrice.Text = rs.GetValue("lblPrice", rc).ValueAsString;
                lblLanguage.Text = rs.GetValue("lblLanguage", rc).ValueAsString;
                btnCreate.Content = rs.GetValue("btnCreate", rc).ValueAsString;

                //Xác định ngôn ngữ chính dựa trên culture (mã ngôn ngữ-mã quốc gia)
                //Giờ datetime tùy theo quốc gia nên phải chọn ngôn ngữ chính trước.
                //Hoặc set datetime ngoài if else cho đơn giản
                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            }

            if (choice == "vi")
            {
                var culture = new CultureInfo("vi-VN");
                var rs = ResourceManager.Current.MainResourceMap.GetSubtree("viResources");
                lblPageTitle.Text = rs.GetValue("lblPageTitle", rc).ValueAsString;
                lblTitle.Text = rs.GetValue("lblTitle", rc).ValueAsString;
                lblGenre.Text = rs.GetValue("lblGenre", rc).ValueAsString;
                lblYear.Text = rs.GetValue("lblYear", rc).ValueAsString;
                lblPrice.Text = rs.GetValue("lblPrice", rc).ValueAsString;
                lblLanguage.Text = rs.GetValue("lblLanguage", rc).ValueAsString;
                btnCreate.Content = rs.GetValue("btnCreate", rc).ValueAsString;

                ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            }
            //tblDate.Text = new DateTimeFormatter("longdate").Format(DateTimeOffset.Now);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}