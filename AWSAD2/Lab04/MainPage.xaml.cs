using Limilabs.Client.SMTP;
using Limilabs.Mail;
using Limilabs.Mail.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace Lab04
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private StorageFile file;

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                MailBuilder mb = new MailBuilder();
                mb.From.Add(new MailBox(txtFrom.Text));
                mb.To.Add(new MailBox(txtTo.Text));
                mb.Subject = txtSubject.Text;
                mb.Html = txtBody.Text;
                if (file != null)
                {
                    await mb.AddAttachment(file);
                }

                IMail mail = mb.Create();
                try
                {
                    Smtp smtp = new Smtp();
                    await smtp.Connect("smtp.gmail.com", 587);
                    await smtp.UseBestLoginAsync(txtFrom.Text, txtPasscode.Password);

                    await smtp.SendMessageAsync(mail);

                    await smtp.CloseAsync();
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();

                    //throw;
                }
            }
            await new MessageDialog("Send mail completed").ShowAsync();
        }

        private async void btnAttachFile_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();

            fop.FileTypeFilter.Add(".png");
            fop.FileTypeFilter.Add(".jpg");
            fop.SuggestedStartLocation = PickerLocationId.Desktop;
            file = await fop.PickSingleFileAsync();
            if (file != null)
            {
                tblFile.Text = file.Path;
            }
        }
    }
}