using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _14_StronglyTypedDatasets
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                string Query = "Select * From StudentTable";
                SqlDataAdapter da = new SqlDataAdapter(Query, con);

                DataSet ds = new DataSet();
                da.Fill(ds, "Students");
                Session["DATASET"] = ds;

                GridView.DataSource = from DataRow in ds.Tables["Students"].AsEnumerable()
                                      select new Student
                                      {
                                          ID = Convert.ToInt32(DataRow["ID"]),
                                          Name = DataRow["Name"].ToString(),
                                          Gender = DataRow["Gender"].ToString(),
                                          TotalMarks = Convert.ToInt32(DataRow["TotalMarks"])
                                      };
                GridView.DataBind();
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Session["DATASET"];

            if(string.IsNullOrEmpty(TextBox.Text))
            {
                GridView.DataSource = from DataRow in ds.Tables["Students"].AsEnumerable()
                                      select new Student
                                      {
                                          ID = Convert.ToInt32(DataRow["ID"]),
                                          Name = DataRow["Name"].ToString(),
                                          Gender = DataRow["Gender"].ToString(),
                                          TotalMarks = Convert.ToInt32(DataRow["TotalMarks"])
                                      };
                GridView.DataBind();
            }
            else
            {
                GridView.DataSource = from DataRow in ds.Tables["Students"].AsEnumerable()
                                      where DataRow["Name"].ToString().ToUpper().StartsWith(TextBox.Text.ToString().ToUpper())
                                      select new Student
                                      {
                                          ID = Convert.ToInt32(DataRow["ID"]),
                                          Name = DataRow["Name"].ToString(),
                                          Gender = DataRow["Gender"].ToString(),
                                          TotalMarks = Convert.ToInt32(DataRow["TotalMarks"])
                                      };
                GridView.DataBind();
            }
        }
    }
}