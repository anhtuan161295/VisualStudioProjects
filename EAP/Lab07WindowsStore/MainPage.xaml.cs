using Lab07WindowsStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab07WindowsStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        HttpClient httpClient = new HttpClient();
        private string url = "http://localhost:2756/api/Albums/";

        public MainPage()
        {
            this.InitializeComponent();
            loadAlbums();
        }

        private void loadAlbums()
        {
            var model =
                JsonConvert.DeserializeObjectAsync<IEnumerable<Album>>(httpClient.GetStringAsync(url).Result).Result;
            gvAlbums.DataContext = model;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var album = new Album()
            {
                Title = txtTitle.Text,
                Genre = txtGenre.Text,
                YearOfRelease = txtYearOfRelease.Text
            };
            //var model = httpClient.PostAsync(url, album).Result;
        }
    }
}