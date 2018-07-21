using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab05
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

        private StorageFile saveFile;

        private async void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.SuggestedStartLocation = PickerLocationId.Desktop;
            fop.FileTypeFilter.Add(".mp3");
            fop.FileTypeFilter.Add(".mp4");
            var file = await fop.PickSingleFileAsync();
            if (file != null)
            {
                mediaElement.SetSource(await file.OpenAsync(FileAccessMode.Read), file.ContentType);
                mediaElement.Play();
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
        }

        private async void btnWebCam_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI camera = new CameraCaptureUI();
            camera.PhotoSettings.CroppedAspectRatio = new Size(15, 9);
            file = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (file != null)
            {
                BitmapImage bm = new BitmapImage();
                bm.SetSource(await file.OpenAsync(FileAccessMode.Read));
                img.Source = bm;
            }
        }

        private void btnMute_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.IsMuted == true)
            {
                mediaElement.IsMuted = false;
            }
            else
            {
                mediaElement.IsMuted = true;
            }
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.PlaybackRate++;
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.PlaybackRate--;
        }

        private void btnVolume_Click(object sender, RoutedEventArgs e)
        {
        }

        private async void btnSavePhoto_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker fsp = new FileSavePicker();
            fsp.SuggestedStartLocation = PickerLocationId.Desktop;
            fsp.FileTypeChoices.Add("PNG", new List<string> { ".png" });
            saveFile = await fsp.PickSaveFileAsync();
            if (saveFile != null)
            {
                await file.CopyAndReplaceAsync(saveFile);
            }
        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (mediaElement != null)
            {
                mediaElement.Volume = slider.Value;
            }
        }
    }
}