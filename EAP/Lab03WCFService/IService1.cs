using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab03WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here

        // ADO.Net
        [OperationContract]
        DataSet GetProducts();

        [OperationContract]
        void AddProduct(string name, double price, int quantity);

        // Entity Framework
        [OperationContract]
        List<Product> GetProductList();

        [OperationContract]
        Product GetProductById(int id);

        [OperationContract]
        void NewProduct(Product newProduct);
    }
}