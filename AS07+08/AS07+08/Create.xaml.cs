using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace AS07_08
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Create : Page
    {
        public Create()
        {
            this.InitializeComponent();
        }

        public async Task<bool> checkId()
        {
            string id = txtId.Text;
            int a;
            bool isNum = int.TryParse(id, out a);
            do
            {
                if (string.IsNullOrEmpty(id))
                {
                    await new MessageDialog("Id must not be blank").ShowAsync();
                    txtId.Focus(FocusState.Keyboard);
                    return false;
                }
                if (isNum == false)
                {
                    await new MessageDialog("Id must be a number").ShowAsync();
                    txtId.Focus(FocusState.Keyboard);
                    return false;
                }
                if (a <= 0)
                {
                    await new MessageDialog("Id must larger than 0").ShowAsync();
                    txtId.Focus(FocusState.Keyboard);
                    return false;
                }
                return true;
            } while (string.IsNullOrEmpty(id) == false || isNum == false || a <= 0);
        }

        public async Task<bool> checkName()
        {
            string id = txtName.Text;
            do
            {
                if (string.IsNullOrEmpty(id))
                {
                    await new MessageDialog("Name must not be blank").ShowAsync();
                    txtName.Focus(FocusState.Keyboard);
                    return false;
                }

                return true;
            } while (string.IsNullOrEmpty(id) == false);
        }

        public async Task<bool> checkDescribe()
        {
            string id = txtDescribe.Text;

            do
            {
                if (string.IsNullOrEmpty(id))
                {
                    await new MessageDialog("Please enter a describe about product").ShowAsync();
                    txtDescribe.Focus(FocusState.Keyboard);
                    return false;
                }

                return true;
            } while (string.IsNullOrEmpty(id) == false);
        }

        public async Task<bool> checkPrice()
        {
            string id = txtPrice.Text;
            double a;
            bool isNum = double.TryParse(id, out a);
            do
            {
                if (string.IsNullOrEmpty(id))
                {
                    await new MessageDialog("Price must not be blank").ShowAsync();
                    txtPrice.Focus(FocusState.Keyboard);
                    return false;
                }
                if (isNum == false)
                {
                    await new MessageDialog("Price must be a number").ShowAsync();
                    txtPrice.Focus(FocusState.Keyboard);
                    return false;
                }
                if (a <= 0)
                {
                    await new MessageDialog("Price must larger than 0").ShowAsync();
                    txtPrice.Focus(FocusState.Keyboard);
                    return false;
                }
                return true;
            } while (string.IsNullOrEmpty(id) == false || isNum == false || a <= 0);
        }

        public async Task<bool> checkQuantity()
        {
            string id = txtQuantity.Text;
            int a;
            bool isNum = int.TryParse(id, out a);
            do
            {
                if (string.IsNullOrEmpty(id))
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
                if (a <= 0)
                {
                    await new MessageDialog("Quantity must larger than 0").ShowAsync();
                    txtQuantity.Focus(FocusState.Keyboard);
                    return false;
                }
                return true;
            } while (string.IsNullOrEmpty(id) == false || isNum == false || a <= 0);
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //1 cách lấy giá trị từ combo box khác
            //ComboBoxItem item = txtManufacture.SelectedItem as ComboBoxItem;
            //string combobox = item.Content.ToString();

            bool check = await checkId() &&
                         await checkName() &&
                         await checkDescribe() &&
                         await checkPrice() &&
                         await checkQuantity();

            if (check == true)
            {
                Computer com = new Computer
               {
                   Id = int.Parse(txtId.Text),
                   Name = txtName.Text,
                   Manufacture = txtManufacture.SelectionBoxItem.ToString(),
                   Describe = txtDescribe.Text,
                   Price = int.Parse(txtPrice.Text),
                   Quantity = int.Parse(txtQuantity.Text)
               };
                ComputerData.cList.Add(com);
                await new MessageDialog("Create success").ShowAsync();
            }
        }
    }
}