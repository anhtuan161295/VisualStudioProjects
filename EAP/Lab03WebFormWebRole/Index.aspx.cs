using Lab03WebFormWebRole.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab03WebFormWebRole
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadData();
            }
        }

        ServiceReference1.Service1Client sc = new Service1Client();

        private void loadData()
        {
            GridView1.DataSource = null;
            GridView1.DataSource = sc.GetProducts();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                sc.AddProduct(TextBox1.Text, double.Parse(TextBox2.Text), int.Parse(TextBox2.Text));
                Label1.Text = "Add product completed";
                loadData();
            }
            catch (Exception)
            {
            }
        }
    }
}