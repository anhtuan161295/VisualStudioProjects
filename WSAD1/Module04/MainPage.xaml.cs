using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Module04.Model;
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
using UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Module04
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /*
         * ID là số từ 1-1000
         * Name ko dc để trống, độ dài 3-12 kí tự
         * Price, Quantity là số lớn hơn 0

         */

        public MainPage()
        {
            this.InitializeComponent();
            loadProduct();
            btnOpenFile.Visibility = Visibility.Collapsed;
            btnSaveFile.Opacity = 0;
        }

        private void loadProduct()
        {
            gvProduct.ItemsSource = Model.ProductContext.pList;
        }

        private static bool checkRegex(string input, string regex)
        {
            try
            {
                var rs = new Regex(input);
                return rs.IsMatch(regex);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<bool> checkID()
        {
            string id = txtId.Text;
            int a;
            bool isNum = int.TryParse(id, out a);

            do
            {
                if (string.IsNullOrEmpty(id))
                {
                    await new MessageDialog("ID must not be blank").ShowAsync();
                    txtId.Focus(FocusState.Keyboard);
                    return false;
                }
                else if (isNum == true)
                {
                    if (a < 1 || a > 1000)
                    {
                        await new MessageDialog("ID must be from 1 to 1000").ShowAsync();
                        txtId.Focus(FocusState.Keyboard);
                        return false;
                    }
                }
                else if (isNum == false)
                {
                    await new MessageDialog("ID must be a number").ShowAsync();
                    txtId.Focus(FocusState.Keyboard);
                    return false;
                }
                return true;
            } while (isNum == false || a < 1 || a > 1000);
        }

        private async Task<bool> checkName()
        {
            string name = txtName.Text;

            do
            {
                if (string.IsNullOrEmpty(name))
                {
                    await new MessageDialog("Name must not be blank").ShowAsync();
                    txtName.Focus(FocusState.Keyboard);
                    return false;
                }
                else if (name.Length < 3 || name.Length > 12)
                {
                    await new MessageDialog("Name length must be from 3 to 12 characters").ShowAsync();
                    txtName.Focus(FocusState.Keyboard);
                    return false;
                }
                return true;
            } while (string.IsNullOrEmpty(name) == false || name.Length < 3 || name.Length > 12);
        }

        private async Task<bool> checkQuantity()
        {
            string quantity = txtQuantity.Text;
            int a;
            bool isNum = int.TryParse(quantity, out a);

            do
            {
                if (string.IsNullOrEmpty(quantity))
                {
                    await new MessageDialog("Quantity must not be blank").ShowAsync();
                    txtQuantity.Focus(FocusState.Keyboard);
                    return false;
                }
                if (isNum == false)
                {
                    await new MessageDialog("Quantity must be a number").ShowAsync();
                    txtQuantity.Focus(FocusState.Keyboard);
                    return false;
                }
                else if (a < 0 || a == 0)
                {
                    await new MessageDialog("Quantity must be larger than 0").ShowAsync();
                    txtQuantity.Focus(FocusState.Keyboard);
                    return false;
                }
                return true;
            } while (string.IsNullOrEmpty(quantity) == false || isNum == false || a < 0 || a == 0);
        }

        private async Task<bool> checkPrice()
        {
            string price = txtPrice.Text;
            double a;
            bool isNum = double.TryParse(price, out a);

            do
            {
                if (string.IsNullOrEmpty(price))
                {
                    await new MessageDialog("Price must not be blank").ShowAsync();
                    txtPrice.Focus(FocusState.Keyboard);
                    return false;
                }
                else if (isNum == false)
                {
                    await new MessageDialog("Price must be a number").ShowAsync();
                    txtPrice.Focus(FocusState.Keyboard);
                    return false;
                }
                else if (a < 0 || a == 0)
                {
                    await new MessageDialog("Price must be larger than 0").ShowAsync();
                    txtPrice.Focus(FocusState.Keyboard);
                    return false;
                }
                return true;
            } while (isNum == false || a < 0 || a == 0);
        }

        private void gvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Product product = gvProduct.SelectedItem as Model.Product;
            ObservableCollection<Model.Product> newList = new ObservableCollection<Product>();
            newList.Add(product);
            lvDetails.ItemsSource = newList;
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            bool check = await checkID() &&
                await checkName() &&
                await checkQuantity() &&
                await checkPrice();

            if (check == true)
            {
                Model.Product pro = new Product()
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtName.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    Price = double.Parse(txtPrice.Text)
                };
                Model.ProductContext.pList.Add(pro);
                lblMessage.Text = "Add product completed successful";
                btnOpenFile.Visibility = Visibility.Visible;
                btnSaveFile.Opacity = 1;
            }
        }

        private async void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Model.ProductContext.pList)
            {
                sb.AppendLine(item.ToString());
            }
            FileSavePicker fsp = new FileSavePicker();
            fsp.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            fsp.FileTypeChoices.Add("Text File", new List<string> { ".txt" });
            StorageFile file = await fsp.PickSaveFileAsync();
            if (file != null)
            {
                await FileIO.WriteTextAsync(file, sb.ToString());
                lblMessage.Text = "Save file to success";
            }
        }

        private async void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            fop.FileTypeFilter.Add(".txt");
            fop.FileTypeFilter.Add(".doc");
            StorageFile file = await fop.PickSingleFileAsync();
            if (file != null)
            {
                string[] str = (await FileIO.ReadTextAsync(file)).Trim().Split('\r');
                string[] character = { " ", "\t", "\r" };
                string[] result;
                Model.ProductContext.pList.Clear();
                foreach (var item in str)
                {
                    result = item.Split(character, StringSplitOptions.RemoveEmptyEntries);
                    Model.Product newPro = new Model.Product
                {
                    Id = int.Parse(result[0]),
                    Name = result[1],
                    Quantity = int.Parse(result[2]),
                    Price = double.Parse(result[3])
                };
                    Model.ProductContext.pList.Add(newPro);
                }
            }
            gvProduct.ItemsSource = Model.ProductContext.pList;
        }
    }
}