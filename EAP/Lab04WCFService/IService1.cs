using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab04WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here

        [OperationContract]
        void SendMoney(string txtSender, string txtReceiver, string txtAmountToSend);

        [OperationContract]
        List<Account> GetAccountList();

        [OperationContract]
        void Deposit(string account, int amount);

        [OperationContract]
        void Withdraw(string account, int amount);

        [OperationContract]
        List<vBookPublisher> GetBookList();

        [OperationContract]
        List<Publisher> GetPublishers();

        [OperationContract]
        Book GetBookById(int id);

        [OperationContract]
        void addPublisher(Publisher newPub);

        [OperationContract]
        void addBook(Book newBook);

        [OperationContract]
        void updateBook(Book editBook);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}