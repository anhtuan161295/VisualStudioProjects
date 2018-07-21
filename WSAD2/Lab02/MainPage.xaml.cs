using Lab02.Model;
using Newtonsoft.Json;
using NotificationsExtensions.ToastContent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Popups;
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

            this.setLiveTile("facebook.png", "FFDD", 20);

            this.loadAlbums();
        }

        private void setLiveTile(string imgPath, string text, int second)
        {
            //Chọn tile template
            var tile = TileTemplateType.TileSquare150x150PeekImageAndText04;
            var tileTemplate = TileUpdateManager.GetTemplateContent(tile);
            //Tạo notification
            var notifi = new TileNotification(tileTemplate);
            notifi.ExpirationTime = DateTime.Now + TimeSpan.FromSeconds(second);
            //Tạo xml để đưa icon và Text lên Tile
            XmlNodeList node = tileTemplate.GetElementsByTagName("image");
            node[0].Attributes[1].NodeValue = "ms-appx:///Assets/" + imgPath;
            tileTemplate.GetElementsByTagName("text");
            node[0].InnerText = text;

            //Cập nhật tile
            var tud = TileUpdateManager.CreateTileUpdaterForApplication();
            tud.Update(notifi);
        }

        private void loadAlbums()
        {
            gvAlbums.ItemsSource = Model.AlbumContext.aList;
        }

        private void toastMessage(string img, string text)
        {
            IToastNotificationContent itnc = null;
            //Tạo toast message template
            IToastImageAndText01 itoast = ToastContentFactory.CreateToastImageAndText01();
            //Đưa nội dung message lên itoast
            itoast.TextBodyWrap.Text = text;
            //Đưa image lên itoast
            itoast.Image.Src = "ms-appx:///Assets/" + img;

            itnc = itoast;

            //Tạo toast message
            ToastNotification tnc = itnc.CreateNotification();
            //Hiển thị toast message
            ToastNotificationManager.CreateToastNotifier().Show(tnc);
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                //await new MessageDialog("Title is required").ShowAsync();
                toastMessage("imageToast.png", "Title is required");
                txtTitle.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtGenre.Text))
            {
                //await new MessageDialog("Genre is required").ShowAsync();
                toastMessage("imageToast.png", "Genre is required");
                txtGenre.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtYear.Text) || int.Parse(txtYear.Text) < 1900 || int.Parse(txtYear.Text) > 2016)
            {
                //await new MessageDialog("Year Of Release is required").ShowAsync();
                toastMessage("imageToast.png", "Year Of Release is required");
                txtYear.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                Model.Album album = new Album
                {
                    Title = txtTitle.Text,
                    Genre = txtGenre.Text,
                    Year = txtYear.Text
                };
                Model.AlbumContext.aList.Add(album);
                await new MessageDialog("Add album completed").ShowAsync();
                //loadAlbums();
            }
        }

        private void searchBox_QueryChanged(SearchBox sender, SearchBoxQueryChangedEventArgs args)
        {
            ObservableCollection<Album> sList = new ObservableCollection<Album>();
            foreach (var item in Model.AlbumContext.aList)
            {
                if (item.Title.ToLower().Contains(searchBox.QueryText.ToLower()))
                {
                    sList.Add(item);
                }
            }
            gvAlbums.ItemsSource = sList;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (Model.AlbumContext.aList != null)
            {
                Model.Album album = gvAlbums.SelectedItem as Album;
                Model.AlbumContext.aList.Remove(album);
                gvAlbums.ItemsSource = Model.AlbumContext.aList;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (gvAlbums.SelectedItem != null)
            {
                Album album = gvAlbums.SelectedItem as Album;

                foreach (var item in Model.AlbumContext.aList)
                {
                    if (item.Title.Equals(album.Title))
                    {
                        item.Genre = txtGenre.Text;
                        item.Year = txtYear.Text;
                    }
                }
                gvAlbums.ItemsSource = null;
                gvAlbums.ItemsSource = Model.AlbumContext.aList;
                toastMessage("imageToast.png", "Update album completed");
            }
        }
    }
}