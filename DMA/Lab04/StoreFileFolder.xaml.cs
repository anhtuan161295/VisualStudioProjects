using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Lab04
{
    public partial class StoreFileFolder : PhoneApplicationPage
    {
        public StoreFileFolder()
        {
            InitializeComponent();
        }

        IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isf.DirectoryExists("MyGame"))
                {
                    isf.CreateDirectory("MyGame");
                }
                else
                {
                    //do nothing
                }
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(@"MyGame\Game.txt", FileMode.Create, isf))
                {
                    StreamWriter sw = new StreamWriter(isfs);
                    sw.WriteLine(txtTitle.Text);
                    sw.WriteLine(txtYear.Text);
                    sw.WriteLine(txtPrice.Text);
                    sw.Flush();
                    sw.Close();
                }
                MessageBox.Show("Add game completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                if (!isf.DirectoryExists("MyGame"))
                {
                    MessageBox.Show("File not found!");
                }
                else
                {
                    using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(@"MyGame\Game.txt", FileMode.Open, isf))
                    {
                        StreamReader sr = new StreamReader(isfs);
                        sb.AppendLine(sr.ReadToEnd());
                        MessageBox.Show(sb.ToString());
                        sr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}