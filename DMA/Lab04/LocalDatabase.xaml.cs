using Lab04.Models;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Lab04
{
    public partial class LocalDatabase : PhoneApplicationPage
    {
        public LocalDatabase()
        {
            InitializeComponent();
        }

        Models.GameContext db = new Models.GameContext("isostore:/game.sdf");

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.DatabaseExists() == false)
            {
                db.CreateDatabase();
            }
            else
            {
                //do nothing
            }
            try
            {
                Models.Game game = new Game()
                {
                    Title = txtTitle.Text,
                    Year = txtYear.Text,
                    Price = double.Parse(txtPrice.Text)
                };
                db.Games.InsertOnSubmit(game);
                db.SubmitChanges();
                MessageBox.Show("Add game completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            //var res = from g
            //              in db.Games
            //          select g;
            //listBox.ItemsSource = res;

            listBox.ItemsSource = db.Games;
        }
    }
}