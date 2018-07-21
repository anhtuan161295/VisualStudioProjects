using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Lab02
{
    public partial class Game : PhoneApplicationPage
    {
        public Game()
        {
            InitializeComponent();
            longlistGame.ItemsSource = Models.GameContext.gList;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //Id
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Id is required!");
                return;
            }
            else if (Regex.IsMatch(txtId.Text, "\\d+") == false)
            {
                MessageBox.Show("Id is invalid. Id must be a number!");
                return;
            }
            //Title
            else if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Title is required!");
                return;
            }
            else if (txtTitle.Text.Length < 3)
            {
                MessageBox.Show("Title is invalid. Title length must be larger than 3 character !");
                return;
            }
            //Genre
            else if (string.IsNullOrEmpty(txtGenre.Text))
            {
                MessageBox.Show("Genre is required!");
                return;
            }
            else if (txtGenre.Text != "hanh dong" && txtGenre.Text != "giai tri")
            {
                MessageBox.Show("Genre is invalid. Genre must be 'hanh dong' or 'giai tri' !");
                return;
            }
            //Year
            else if (string.IsNullOrEmpty(txtYear.Text))
            {
                MessageBox.Show("Year is required!");
                return;
            }
            //Price
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Price is required!");
                return;
            }
            else if (Regex.IsMatch(txtPrice.Text, "\\d+") == false)
            {
                MessageBox.Show("Price is invalid. Price must be a number!");
                return;
            }
            else if (double.Parse(txtPrice.Text) <= 0)
            {
                MessageBox.Show("Price is invalid. Price must be larger than 0!");
                return;
            }
            else
            {
                Models.Game game = new Models.Game();
                game._Id = int.Parse(txtId.Text);
                game._Title = txtTitle.Text;
                game._Genre = txtGenre.Text;
                game._YearOfRelease = txtYear.Text;
                game._Price = double.Parse(txtPrice.Text);
                Models.GameContext.gList.Add(game);
                MessageBox.Show("Add game completed!");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var item = longlistGame.SelectedItem;
            if (item != null & longlistGame.ItemsSource.Count > 0)
            {
                var box = MessageBox.Show("Are you sure to remove this item ?", "Remove item", MessageBoxButton.OKCancel);
                if (box == MessageBoxResult.OK)
                {
                    longlistGame.ItemsSource.Remove(item);
                    MessageBox.Show("Remove game completed!");
                }
            }
            else
            {
                MessageBox.Show("Item invalid!");
            }
            longlistGame.SelectedItem = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            var model = (sender as Button).DataContext as Models.Game;
            pivotMain.SelectedIndex = 2;
            pivotUpdate.Visibility = Visibility.Visible;

            if (model != null)
            {
                txtId1.Text = model._Id.ToString();
                txtTitle1.Text = model._Title;
                txtGenre1.Text = model._Genre;
                txtYear1.Text = model._YearOfRelease;
                txtPrice1.Text = model._Price.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = Models.GameContext.gList.SingleOrDefault(u => u._Id == int.Parse(txtId1.Text));

            if (model != null)
            {
                //Id
                if (string.IsNullOrEmpty(txtId1.Text))
                {
                    MessageBox.Show("Id is required!");
                    return;
                }
                else if (Regex.IsMatch(txtId1.Text, "^\\d+$") == false)
                {
                    MessageBox.Show("Id is invalid. Id must be a number!");
                    return;
                }
                //Title
                else if (string.IsNullOrEmpty(txtTitle1.Text))
                {
                    MessageBox.Show("Title is required!");
                    return;
                }
                else if (txtTitle1.Text.Length < 3)
                {
                    MessageBox.Show("Title is invalid. Title length must be larger than 3 character !");
                    return;
                }
                //Genre
                else if (string.IsNullOrEmpty(txtGenre1.Text))
                {
                    MessageBox.Show("Genre is required!");
                    return;
                }
                else if (txtGenre1.Text != "hanh dong" && txtGenre1.Text != "giai tri")
                {
                    MessageBox.Show("Genre is invalid. Genre must be 'hanh dong' or 'giai tri' !");
                    return;
                }
                //Year
                else if (string.IsNullOrEmpty(txtYear1.Text))
                {
                    MessageBox.Show("Year is required!");
                    return;
                }
                //Price
                else if (string.IsNullOrEmpty(txtPrice1.Text))
                {
                    MessageBox.Show("Price is required!");
                    return;
                }
                else if (Regex.IsMatch(txtPrice1.Text, "^\\d+$") == false)
                {
                    MessageBox.Show("Price is invalid. Price must be a number!");
                    return;
                }
                else if (double.Parse(txtPrice1.Text) <= 0)
                {
                    MessageBox.Show("Price is invalid. Price must be larger than 0!");
                    return;
                }
                else
                {
                    model._Title = txtTitle1.Text;
                    model._Genre = txtGenre1.Text;
                    model._YearOfRelease = txtYear1.Text;
                    model._Price = double.Parse(txtPrice1.Text);
                    MessageBox.Show("Save game completed!");
                    longlistGame.ItemsSource = null;
                    longlistGame.ItemsSource = Models.GameContext.gList;
                }
            }
        }
    }
}