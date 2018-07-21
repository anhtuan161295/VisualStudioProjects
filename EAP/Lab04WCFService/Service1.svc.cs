using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Transactions;

namespace Lab04WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public List<Account> GetAccountList()
        {
            return db.Accounts.ToList();
        }

        public void SendMoney(string txtSender, string txtReceiver, string txtAmountToSend)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var amount = int.Parse(txtAmountToSend);
                var sender = db.Accounts.Single(u => u.AccountName.Equals(txtSender));
                var receiver = db.Accounts.Single(u => u.AccountName.Equals(txtReceiver));

                if (sender != null && receiver != null)
                {
                    sender.Balance -= amount;
                    receiver.Balance += amount;
                }
                db.SubmitChanges();
                ts.Complete();
            }
        }

        public void Deposit(string account, int amount)
        {
            //deposit
            using (TransactionScope ts = new TransactionScope())
            {
                //Update account
                //Balance +=Account
                //Insert
                //TransactionType
                var acc = db.Accounts.Single(u => u.AccountName == account);
                if (acc != null)
                {
                    acc.Balance += amount;
                    var log = new TransactionType()
                    {
                        AccountName = account,
                        Amount = amount,
                        Date = DateTime.Now,
                        Type = "Deposit"
                    };
                    db.TransactionTypes.InsertOnSubmit(log);
                }
                db.SubmitChanges();

                ts.Complete();
            }
        }

        public void Withdraw(string account, int amount)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var acc = db.Accounts.Single(u => u.AccountName == account);
                if (acc != null)
                {
                    acc.Balance -= amount;
                    var log = new TransactionType()
                    {
                        AccountName = account,
                        Amount = amount,
                        Date = DateTime.Now,
                        Type = "Withdraw"
                    };
                    db.TransactionTypes.InsertOnSubmit(log);
                }
                db.SubmitChanges();

                ts.Complete();
            }
        }

        public List<vBookPublisher> GetBookList()
        {
            var res = (from b in db.vBookPublishers
                       orderby b.PublisherName ascending
                       //group b.PublisherName by b
                       select b).ToList();
            return res;
        }

        public List<Publisher> GetPublishers()
        {
            var res = (from p in db.Publishers
                           //orderby b.PublisherName ascending
                           //group b.PublisherName by b
                       select p).ToList();
            return res;
        }

        public Book GetBookById(int id)
        {
            var res = (from b in db.Books
                       where b.BookId == id
                       select b).Single();
            return res;
        }

        public void addPublisher(Publisher newPub)
        {
            db.Publishers.InsertOnSubmit(newPub);
            db.SubmitChanges();
        }

        public void addBook(Book newBook)
        {
            db.Books.InsertOnSubmit(newBook);
            db.SubmitChanges();
        }

        public void updateBook(Book editBook)
        {
            var book = (from i in db.Books
                        where i.BookId == editBook.BookId
                        select i).Single();

            if (book != null)
            {
                book.BookName = editBook.BookName;
                book.Author = editBook.Author;
                book.Price = editBook.Price;
                book.Edition = editBook.Edition;
                db.SubmitChanges();
            }
        }
    }
}