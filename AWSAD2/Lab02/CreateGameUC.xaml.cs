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

namespace Lab02
{
    public sealed partial class CreateGameUC : UserControl
    {
        public CreateGameUC()
        {
            this.InitializeComponent();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                await new MessageDialog("ID can not be blank").ShowAsync();
                txtId.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtTitle.Text) || txtTitle.Text.Length < 3 || txtTitle.Text.Length > 10)
            {
                await new MessageDialog("Title can not be blank").ShowAsync();
                txtTitle.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtGenre.Text))
            {
                await new MessageDialog("Genre can not be blank").ShowAsync();
                txtGenre.Focus(FocusState.Keyboard);
                return;
            }
            else if (string.IsNullOrEmpty(txtROY.Text))
            {
                await new MessageDialog("ROY can not be blank").ShowAsync();
                txtROY.Focus(FocusState.Keyboard);
                return;
            }
            else
            {
                Models.Game game = new Models.Game
                {
                    Id = int.Parse(txtId.Text),
                    Title = txtTitle.Text,
                    Genre = txtGenre.Text,
                    Year = txtROY.Text,
                };
                Models.GameContext.gList.Add(game);
                await new MessageDialog("Add account completed").ShowAsync();
            }
        }
    }
}