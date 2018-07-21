using Lab03.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab03
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateAccount : Page
    {
        public CreateAccount()
        {
            this.InitializeComponent();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            bool isDouble = double.TryParse(txtBalance.Text, out temp);
            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text.Length < 3 || txtName.Text.Length > 30)
            {
                await new MessageDialog("Account Name is required").ShowAsync();
                txtName.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtFullName.Text) || txtFullName.Text.Length < 3 || txtFullName.Text.Length > 30)
            {
                await new MessageDialog("Full Name is required").ShowAsync();
                txtFullName.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                await new MessageDialog("Address is required").ShowAsync();
                txtAddress.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                await new MessageDialog("Email is required").ShowAsync();
                txtEmail.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                await new MessageDialog("Phone is required").ShowAsync();
                txtPhone.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtBalance.Text) || isDouble == false)
            {
                await new MessageDialog("Balance is required").ShowAsync();
                txtBalance.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                Models.Account account = new Account
                {
                    AccountName = txtName.Text,
                    FullName = txtFullName.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Balance = double.Parse(txtBalance.Text)
                };
                Models.AccountDB.accountList.Add(account);
                await new MessageDialog("Add account completed").ShowAsync();
            }
        }

        private async void btnExport_Click(object sender, RoutedEventArgs e)
        {
            //Convert từ collection > JSon
            var data = await JsonConvert.SerializeObjectAsync(Models.AccountDB.accountList);
            //Tạo file Account.txt, replace nếu có
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Account.txt", CreationCollisionOption.ReplaceExisting);
            //Nếu file đã tạo thì chép dữ liệu từ data vào file
            if (file != null)
            {
                using (var sw = new StreamWriter(await file.OpenStreamForWriteAsync()))
                {
                    sw.Write(data);
                    await sw.FlushAsync();
                }
                tblMess.Text = "Export data completed";
            }
        }

        private async void btnImport_Click(object sender, RoutedEventArgs e)
        {
            //Xóa hết item trong collection
            Models.AccountDB.accountList.Clear();
            //Lấy file đã tạo
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("Account.txt");
            //Convert từ JSon > Collection kiểu Account
            //Chép dữ liệu vào collection trong AccountDB
            //Nếu ko có file thì báo File not found
            if (file != null)
            {
                using (var sr = new StreamReader(await file.OpenStreamForReadAsync()))
                {
                    Models.AccountDB.accountList = await JsonConvert.DeserializeObjectAsync<ObservableCollection<Models.Account>>(await sr.ReadToEndAsync());
                }
                tblMess.Text = "Import data completed";
            }
            else
            {
                tblMess.Text = "File not found";
            }
        }
    }
}