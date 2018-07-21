using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Venetasoft.WP.Net;

namespace Lab05
{
    public partial class EmailTask : PhoneApplicationPage
    {
        public EmailTask()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage mm = new MailMessage()
            {
                AccountType = MailMessage.AccountTypeEnum.Gmail,
                From = txtFrom.Text,
                UserName = txtFrom.Text,
                Password = txtPass.Password,
                To = txtTo.Text,
                Subject = txtSubject.Text,
                Body = txtBody.Text
            };
                mm.Send();
                MessageBox.Show("Send mail completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}