using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_SqlCommand
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "Select * from ProductTable";
                cmd.Connection = con;
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();  //ExecuteReader()=>Return Multiple Records
                GridView1.DataBind();
                con.Close();


                cmd.CommandText = "Select Count(ProductID) from ProductTable";
                cmd.Connection = con;
                con.Open();
                int count = (int)cmd.ExecuteScalar();     //ExecuteScalar()=>Return Only One Record
                Response.Write("Total Number of Product: " + count + "<br>");
                con.Close();


                //ExecuteNonQuery()=>Use for Insert, Delate, Update command and Return number of row affected
                cmd.Connection = con;
                con.Open();

                cmd.CommandText = "Insert into ProductTable values(4,'Calculator',200,250)";
                int insertRowCount = cmd.ExecuteNonQuery();
                Response.Write("Total Number of Row Inserted: " + insertRowCount +"<br>");

                cmd.CommandText = "delete from ProductTable where ProductId=4";
                int deleteRowCount = cmd.ExecuteNonQuery();
                Response.Write("Total Number of Row Deleted: " + deleteRowCount + "<br>");

                cmd.CommandText = "Update ProductTable set QtyAvailable=500 where ProductId=3";
                int UpdateRowCount = cmd.ExecuteNonQuery();
                Response.Write("Total Number of Row Updated: " + UpdateRowCount + "<br>");





            }
        }
    }
}