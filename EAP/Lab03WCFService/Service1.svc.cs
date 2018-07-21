using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab03WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        ProductContext db = new ProductContext();

        // ADO.Net
        public DataSet GetProducts()
        {
            using (SqlConnection sqlcon = new SqlConnection("server=.;database=Lab3;uid=sa;pwd=123456"))
            {
                var sqlda = new SqlDataAdapter("SELECT * FROM Products", sqlcon);
                var ds = new DataSet();
                sqlda.Fill(ds, "Products");
                return ds;
            }
        }

        public void AddProduct(string name, double price, int quantity)
        {
            double total = price * quantity;
            using (SqlConnection sqlcon = new SqlConnection("server=.;database=Lab3;uid=sa;pwd=123456"))
            {
                var sqlda = new SqlDataAdapter("INSERT Products(ProductName,Price,Quantity,Total) VALUES('" + name + "','" + price + "','" + quantity + "','" + total + "')", sqlcon);
                var ds = new DataSet();
                sqlda.Fill(ds, "Products");
            }
        }

        // Entity Framework
        public List<Product> GetProductList()
        {
            return db.ProductList.ToList();
        }

        public Product GetProductById(int id)
        {
            return db.ProductList.Find(id);
        }

        public void NewProduct(Product newProduct)
        {
            db.ProductList.Add(newProduct);
            db.SaveChanges();
        }
    }
}