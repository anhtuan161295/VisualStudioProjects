using Lab04.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class ViewProduct : Page
    {
        public ViewProduct()
        {
            this.InitializeComponent();

            lvProducts.ItemsSource = Models.ProductContext.pList;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null);
        }

        private void SearchBox_QueryChanged(SearchBox sender, SearchBoxQueryChangedEventArgs args)
        {
            var model = Models.ProductContext.pList.Where(p => p.ProductName.Contains(sender.QueryText));
            if (model.Equals(""))
            {
                lvProducts.ItemsSource = Models.ProductContext.pList;
            }
            else
            {
                lvProducts.ItemsSource = model;
            }
        }

        private void lvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Models.Product product = lvProducts.SelectedItem as Product;
            ObservableCollection<Product> newList = new ObservableCollection<Product> { product };
            if (product != null)
            {
                lvDetails.ItemsSource = newList;
            }
        }
    }
}