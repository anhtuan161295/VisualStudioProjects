using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Module05.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Module05
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

        private StorageFile file;
        private string newImg = "";

        private async void btnFile_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.FileTypeFilter.Add(".gif");
            fop.FileTypeFilter.Add(".jpg");
            fop.FileTypeFilter.Add(".png");
            file = await fop.PickSingleFileAsync();
            if (file != null)
            {
                txtImg.Text = file.Name;
                newImg = DateTime.Now.ToString("ddMMyyyyhhmmssffff") + file.FileType;
            }
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Model.Book book = new Book
            {
                ISBN = txtISBN.Text,
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Price = double.Parse(txtPrice.Text),
                Photo = newImg
            };
            if (file != null)
            {
                StorageFolder folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Images", CreationCollisionOption.OpenIfExists);
                await file.CopyAsync(folder, newImg);
            }
            Model.BookContext.bList.Add(book);
            gvBooks.ItemsSource = Model.BookContext.bList;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Book book = gvBooks.SelectedItem as Book;
            Model.BookContext.bList.Remove(book);
        }
    }
}