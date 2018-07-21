using Lab04WSCallWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace Lab04WSCallWebAPI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            loadGames();
        }

        HttpClient httpClient = new HttpClient();
        private string url = "http://localhost:3818/api/Games";

        private void loadGames()
        {
            gvGameList.ItemsSource =
                JsonConvert.DeserializeObjectAsync<IEnumerable<Models.Game>>(httpClient.GetStringAsync(url).Result).Result;
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            int temp;
            bool isNum = int.TryParse(txtId.Text, out temp);
            if (string.IsNullOrEmpty(txtId.Text) || isNum == false)
            {
                await new MessageDialog("Id is required").ShowAsync();
                txtId.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                Models.Game game = new Game
                {
                    Id = int.Parse(txtId.Text),
                    Title = txtTitle.Text,
                    Genre = txtGenre.Text,
                    ReleaseOfYear = txtYear.Text
                };

                var data = httpClient.PostAsJsonAsync<Models.Game>(url, game).Result;
                if (data.IsSuccessStatusCode)
                {
                    await new MessageDialog("Add game completed").ShowAsync();
                    loadGames();
                }
                else
                {
                    await new MessageDialog("Failed").ShowAsync();
                }
            }
        }
    }
}