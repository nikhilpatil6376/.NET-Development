using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05_SqlInjectionPrevention
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
                //Good User TextBox Input => IP Or I etc;
                //Hacker User TextBox Input=> IP';Delete from ProductInventoryTable --

                /*
                   Insert into ProductInventoryTable values
                   (1, 'IPhone',100),
                   (2, 'IPad',200),
                   (3, 'IWatch',300),
                   (4, 'IPod',400)
               */


                /*
                // Using Parameterized Query

                string Command = "Select * from ProductInventoryTable Where ProductName like @ProductName";
                SqlCommand cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@ProductName", TextBox1.Text + '%');
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
                */

                //Using StoreProcedure'
                /*
                create Procedure spGetProductName
                @ProductName nvarchar(20)
                as
                Begin
                select* from ProductInventoryTable where ProductName like @ProductName + '%'
                End
                */

                SqlCommand cmd = new SqlCommand("spGetProductName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", TextBox1.Text + '%');
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
        }
    }
}