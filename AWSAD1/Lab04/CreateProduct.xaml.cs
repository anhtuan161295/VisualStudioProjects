using Lab04.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

namespace Lab04
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateProduct : Page
    {
        public CreateProduct()
        {
            this.InitializeComponent();
            loadImages();
        }

        private void loadImages()
        {
            List<dynamic> listImages = new List<dynamic>
            {
                new {ImgUrl="ms-appx:///Images/h1.png", ImgText="h1.png"},
                new {ImgUrl="ms-appx:///Images/h2.png", ImgText="h2.png"},
                new {ImgUrl="ms-appx:///Images/h3.png", ImgText="h3.png"},
                new {ImgUrl="ms-appx:///Images/h4.png", ImgText="h4.png"}
            };
            cbImg.SelectedValuePath = "ImgText";
            cbImg.ItemsSource = listImages;
            cbImg.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                await new MessageDialog("Id is required").ShowAsync();
                txtId.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtName.Text))
            {
                await new MessageDialog("Name is required").ShowAsync();
                txtName.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                await new MessageDialog("Price is required").ShowAsync();
                txtPrice.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                await new MessageDialog("Quantity is required").ShowAsync();
                txtQuantity.Focus(FocusState.Keyboard);
                return;
            }
            else if (Regex.IsMatch(txtId.Text, "[P][0-9]{5}") == false)
            {
                await new MessageDialog("Id invalid, P and 5 numbers").ShowAsync();
                txtId.Focus(FocusState.Keyboard);
                return;
            }
            else if (Regex.IsMatch(txtPrice.Text, "[0-9]+") == false)
            {
                await new MessageDialog("Price invalid, only numbers").ShowAsync();
                txtPrice.Focus(FocusState.Keyboard);
                return;
            }
            else if (Regex.IsMatch(txtQuantity.Text, "[0-9]+") == false)
            {
                await new MessageDialog("Quantity invalid, only numbers").ShowAsync();
                txtQuantity.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                Models.Product product = new Product
                {
                    ProductId = txtId.Text,
                    ProductName = txtName.Text,
                    Price = double.Parse(txtPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    ImgPath = cbImg.SelectedValue.ToString()
                };
                Models.ProductContext.pList.Add(product);
                await new MessageDialog("Add product completed").ShowAsync();
            }
        }
    }
}