using BookWinRT;
using System;
using System.Collections.Generic;
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
    public sealed partial class CreateBookUserControl : UserControl
    {
        public CreateBookUserControl()
        {
            this.InitializeComponent();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                await new MessageDialog("Id is required").ShowAsync();
                txtId.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                Book book = new Book
                {
                    Id = int.Parse(txtId.Text),
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Price = double.Parse(txtPrice.Text)
                };
                BookModel.bookList.Add(book);
                await new MessageDialog("Add book completed").ShowAsync();
            }
        }
    }
}