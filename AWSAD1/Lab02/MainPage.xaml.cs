using Lab02.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
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

            gvGame.ItemsSource = Models.GameModel.gList;
        }

        private bool check(string input, string regex)
        {
            var rs = new Regex(regex);
            return rs.IsMatch(input);
        }

        private int count = 0;

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                await new MessageDialog("Id is required").ShowAsync();
                txtId.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtTitle.Text) || txtTitle.Text.Length < 3 || txtTitle.Text.Length > 10)
            {
                await new MessageDialog("Title is required. Length from 3 to 10").ShowAsync();
                txtTitle.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtGenre.Text))
            {
                await new MessageDialog("Genre is required").ShowAsync();
                txtGenre.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtYear.Text))
            {
                await new MessageDialog("Year is required").ShowAsync();
                txtYear.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                Models.Game game = new Game
                {
                    Id = int.Parse(txtId.Text),
                    Title = txtTitle.Text,
                    Genre = txtGenre.Text,
                    Year = txtYear.Text
                };
                Models.GameModel.gList.Add(game);

                count = Models.GameModel.gList.Count; //Đếm số game trong gList
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Game.dat", CreationCollisionOption.OpenIfExists);
                if (file != null)
                {
                    using (Stream stream = await file.OpenStreamForWriteAsync())
                    {
                        using (var bw = new BinaryWriter(stream))
                        {
                            bw.Write(count);
                            foreach (var item in Models.GameModel.gList)
                            {
                                bw.Write(item.Id);
                                bw.Write(item.Title);
                                bw.Write(item.Genre);
                                bw.Write(item.Year);
                            }
                            await new MessageDialog("Add game completed").ShowAsync();
                        }
                    }
                    gvGame.ItemsSource = null;
                }
            }
        }

        private async void btnView_Click(object sender, RoutedEventArgs e)
        {
            Models.GameModel.gList.Clear();
            var file = await ApplicationData.Current.LocalFolder.GetFileAsync("Game.dat");
            if (file != null)
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    using (var br = new BinaryReader(stream))
                    {
                        count = br.ReadInt32();
                        for (int i = 0; i < count; i++)
                        {
                            Models.Game game = new Game
                            {
                                Id = br.ReadInt32(),
                                Title = br.ReadString(),
                                Genre = br.ReadString(),
                                Year = br.ReadString()
                            };
                            Models.GameModel.gList.Add(game);
                        }

                        //await new MessageDialog("View game completed").ShowAsync();
                    }
                    gvGame.ItemsSource = Models.GameModel.gList;
                }
            }
            else
            {
                await new MessageDialog("File not found").ShowAsync();
            }
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (gvGame.SelectedItem != null)
            {
                var game = Models.GameModel.gList.SingleOrDefault(u => u.Id.Equals(int.Parse(txtId.Text)));

                game.Title = txtTitle.Text;
                game.Genre = txtGenre.Text;
                game.Year = txtYear.Text;

                //    Models.Game game = gvGame.SelectedItem as Models.Game;
                //    foreach (var item in Models.GameModel.gList)
                //    {
                //        if (item.Id == game.Id)
                //        {
                //            item.Title = txtTitle.Text;
                //            item.Genre = txtGenre.Text;
                //            item.Year = txtYear.Text;
                //        }
                //    }
                count = Models.GameModel.gList.Count; //Đếm số game trong gList
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Game.dat", CreationCollisionOption.ReplaceExisting);
                if (file != null)
                {
                    using (Stream stream = await file.OpenStreamForWriteAsync())
                    {
                        using (var bw = new BinaryWriter(stream))
                        {
                            bw.Write(count);
                            foreach (var item in Models.GameModel.gList)
                            {
                                bw.Write(item.Id);
                                bw.Write(item.Title);
                                bw.Write(item.Genre);
                                bw.Write(item.Year);
                            }
                            await new MessageDialog("Update game completed").ShowAsync();
                        }
                    }
                    gvGame.ItemsSource = null;
                }
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (Models.GameModel.gList.Count > 0)
            {
                var game = Models.GameModel.gList.SingleOrDefault(u => u.Id.Equals(int.Parse(txtId.Text)));

                Models.GameModel.gList.Remove(game);

                //    Models.Game game = gvGame.SelectedItem as Models.Game;
                //    Models.GameModel.gList.Remove(game);
                count = Models.GameModel.gList.Count; //Đếm số game trong gList
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Game.dat", CreationCollisionOption.ReplaceExisting);
                if (file != null)
                {
                    using (Stream stream = await file.OpenStreamForWriteAsync())
                    {
                        using (var bw = new BinaryWriter(stream))
                        {
                            bw.Write(count);
                            foreach (var item in Models.GameModel.gList)
                            {
                                bw.Write(item.Id);
                                bw.Write(item.Title);
                                bw.Write(item.Genre);
                                bw.Write(item.Year);
                            }
                            await new MessageDialog("Delete game completed").ShowAsync();
                        }
                    }
                    gvGame.ItemsSource = null;
                }
            }
        }

        private void gvGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (gvGame.SelectedItem != null)
            //{
            //    Models.Game game = gvGame.SelectedItem as Models.Game;
            //    txtId.Text = game.Id.ToString();
            //    txtTitle.Text = game.Title;
            //    txtGenre.Text = game.Genre;
            //    txtYear.Text = game.Year;
            //}
            //else
            //{
            //    txtId.Text = "";
            //    txtTitle.Text = "";
            //    txtGenre.Text = "";
            //    txtYear.Text = "";
            //}
        }
    }
}