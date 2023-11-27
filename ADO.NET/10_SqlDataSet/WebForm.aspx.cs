using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _10_SqlDataSet
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("spGetData", con);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                da.Fill(ds);

                //ProductInventoryTable.DataSource = ds.Tables[0];
                //ProductInventoryTable.DataSource = ds.Tables["Table"];
                ds.Tables[0].TableName = "ProductInventory";
                ProductInventoryTable.DataSource = ds.Tables["ProductInventory"];
                ProductInventoryTable.DataBind();
                
                //ProductTable.DataSource = ds.Tables[1];
                //ProductTable.DataSource = ds.Tables["Table1"];
                ds.Tables[1].TableName = "Products";
                ProductTable.DataSource = ds.Tables["Products"];
                ProductTable.DataBind();

            }
        }
    }
}