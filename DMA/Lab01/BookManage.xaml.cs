using Lab01.Models;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Lab01
{
    public partial class BookManage : PhoneApplicationPage
    {
        public BookManage()
        {
            InitializeComponent();
            longlistBooks.ItemsSource = Models.BookContext.bList;
            //loadCombobox();
        }

        //private void loadCombobox()
        //{
        //    List<dynamic> list = new List<dynamic>
        //    {
        //        new {imgName="h1.png", imgUrl="Images/h1.png"},
        //        new {imgName="h2.png", imgUrl="Images/h2.png"},
        //        new {imgName="h3.png", imgUrl="Images/h3.png"}
        //    };
        //    cbImg.ItemsSource = list;
        //    cbImg.SelectedValuePath = "imgUrl";
        //    cbImg.SelectedIndex = 0;
        //}

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtISBN.Text))
            {
                MessageBox.Show("ISBN is required!");
                txtISBN.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Title is required!");
                txtTitle.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtAuthor.Text))
            {
                MessageBox.Show("Author is required!");
                txtAuthor.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Unit Price is required!");
                txtPrice.Focus();
                return;
            }
            else
            {
                Models.Book book = new Book
                {
                    ISBN = txtISBN.Text,
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Price = double.Parse(txtPrice.Text)
                };
                Models.BookContext.bList.Add(book);
                MessageBox.Show("Add book completed!");
            }
        }

        private void btnGoogle_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask wbt = new WebBrowserTask();
            wbt.Uri = new Uri("http://www.google.com");
            wbt.Show();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            var book = (sender as Button).DataContext as Book;

            if (book != null)
            {
                pivotBooks.SelectedIndex = 2;
                txtISBN1.Text = book.ISBN;
                txtTitle1.Text = book.Title;
                txtAuthor1.Text = book.Author;
                txtPrice1.Text = book.Price.ToString();
            }
        }

        private void btnUpdate1_Click(object sender, RoutedEventArgs e)
        {
            var newbook = Models.BookContext.bList.SingleOrDefault(u => u.ISBN.Equals(txtISBN1.Text));

            if (newbook != null)
            {
                newbook.Title = txtTitle1.Text;
                newbook.Author = txtAuthor1.Text;
                newbook.Price = double.Parse(txtPrice1.Text);
                MessageBox.Show("Update book completed!");
            }
            else
            {
                MessageBox.Show("Book not found!");
            }
            //foreach (var book in Models.BookContext.bList)
            //{
            //    if (book.ISBN.Equals(txtISBN1.Text))
            //    {
            //        book.Title = txtTitle1.Text;
            //        book.Author = txtAuthor1.Text;
            //        book.Price = double.Parse(txtPrice1.Text);
            //        MessageBox.Show("Update book completed!");
            //    }
            //}
            longlistBooks.ItemsSource = null;
            longlistBooks.ItemsSource = Models.BookContext.bList;
        }
    }
}