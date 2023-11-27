using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace _04_SqlInjection
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string Command = "Select * from ProductInventoryTable Where ProductName like '"+ TextBox1.Text +"%'";

                //Good User TextBox Input => IP Or I etc;
                //Hacker User TextBox Input=> IP';Delete from ProductInventoryTable --

                /*
                   Insert into ProductInventoryTable values
                   (1, 'IPhone',100),
                   (2, 'IPad',200),
                   (3, 'IWatch',300),
                   (4, 'IPod',400)
               */

                SqlCommand cmd = new SqlCommand(Command, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
        }
    }
}