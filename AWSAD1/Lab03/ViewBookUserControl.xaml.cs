using BookWinRT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Lab03
{
    public sealed partial class ViewBookUserControl : UserControl
    {
        public ViewBookUserControl()
        {
            this.InitializeComponent();
            gvBooks.ItemsSource = BookModel.bookList;
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;
            var model = BookModel.bookList.Where(t => t.Title.Contains(search));

            if (model.Any() == true)
            {
                gvBooks.ItemsSource = model;
            }
            else
            {
                gvBooks.ItemsSource = BookModel.bookList;
            }

            //ObservableCollection<Book> newList = new ObservableCollection<Book>();
            //if (search != "")
            //{
            //    foreach (var item in BookModel.bookList)
            //    {
            //        if (item.Title.ToLower().Contains(search.ToLower()))
            //        {
            //            newList.Add(item);
            //        }
            //    }
            //}
            //if (newList.Count > 0)
            //{
            //    gvBooks.ItemsSource = newList;
            //}
            //else
            //{
            //    await new MessageDialog("Book not found").ShowAsync();
            //}
        }
    }
}