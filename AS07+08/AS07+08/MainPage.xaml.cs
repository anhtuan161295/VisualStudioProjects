using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AS07_08
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
            frame.Navigate(typeof(Create), null);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(View), null);
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ComputerData.cList)
            {
                sb.AppendLine(item.ToString());
            }

            FileSavePicker fsp = new FileSavePicker();
            fsp.SuggestedStartLocation = PickerLocationId.Desktop;
            fsp.FileTypeChoices.Add("Text", new List<string> { ".txt" });
            fsp.FileTypeChoices.Add("Word", new List<string> { ".doc" });
            StorageFile file = await fsp.PickSaveFileAsync();
            if (file != null)
            {
                FileIO.WriteTextAsync(file, sb.ToString());
                await new MessageDialog("Save file success").ShowAsync();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}