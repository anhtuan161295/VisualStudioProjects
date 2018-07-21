using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.Models
{
    class UserContext
    {
        public static ObservableCollection<UserAccount> uList = new ObservableCollection<UserAccount>
        {
        };
    }
}