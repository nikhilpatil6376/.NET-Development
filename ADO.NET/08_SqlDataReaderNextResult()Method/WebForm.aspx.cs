using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _08_SqlDataReaderNextResult__Method
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from ProductInventoryTable; select * from ProductTable;", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    ProductInventoryTable.DataSource = rdr;
                    ProductInventoryTable.DataBind();

                   while(rdr.NextResult())
                    {
                        ProductTable.DataSource = rdr;
                        ProductTable.DataBind();
                    }
                }

            }
        }
    }
}