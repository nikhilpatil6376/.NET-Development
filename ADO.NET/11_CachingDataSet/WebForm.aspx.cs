using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _11_CachingDataSet
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            if (Cache["Data"]==null)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select * from ProductTable", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    Cache["Data"] = ds;
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    lblMessage.Text = "Data is loaded from DataSet";
                }
            }
            else
            {
                GridView1.DataSource = Cache["Data"];
                GridView1.DataBind();
                lblMessage.Text = "Data is loaded from Cache";
            }

        }

        protected void btnClearData_Click(object sender, EventArgs e)
        {
            if(Cache["Data"] != null)
            {
                Cache.Remove("Data");
                lblMessage.Text = "Data is cleard from Cache";
            }
            else
            {
                lblMessage.Text = "Nothing is present in Cache";
            }
        }
    }
}