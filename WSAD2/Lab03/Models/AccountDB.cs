using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03.Models
{
    class AccountDB
    {
        public static ObservableCollection<Account> accountList = new ObservableCollection<Account>
        {
            new Account{AccountName = "Obama", FullName = "Adam Obama", Address = "US", Email = "obama@gmail.com", Phone = "0908555555", Balance = 333},
            new Account{AccountName = "Obama", FullName = "Adam Obama", Address = "US", Email = "obama@gmail.com", Phone = "0908555555", Balance = 333}
        };
    }
}