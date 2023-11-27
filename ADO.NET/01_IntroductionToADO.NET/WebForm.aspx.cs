using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace _01_IntroductionToADO.NET
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("data source=.;database=Sample;integrated security=SSPI");
            //SqlCommand cmd = new SqlCommand("Select * from ProductTable", con);
            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            //GridView1.DataSource = rdr;
            //GridView1.DataBind();
            //con.Close();


            //SqlConnection con = new SqlConnection("data source=.;database=Sample;integrated security=SSPI");
            //try
            //{
            //    SqlCommand cmd = new SqlCommand("Select * from ProductTable", con);
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    GridView1.DataSource = rdr;
            //    GridView1.DataBind();
            //}
            //catch (Exception Ex)
            //{

            //}
            //finally
            //{
            //    con.Close();
            //}

            string CS ="data source=.;database=Sample;integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from ProductTable", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
        }
    }
}