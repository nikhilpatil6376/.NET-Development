using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _12_SqlCommandBuilder
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string SqlQuery = "Select * from StudentTable where ID=@ID";
            SqlDataAdapter da = new SqlDataAdapter(SqlQuery, CS);
            da.SelectCommand.Parameters.AddWithValue("@ID", txtID.Text);
            DataSet ds = new DataSet();
            da.Fill(ds, "Student");

            ViewState["SqlQuery"] = SqlQuery;
            ViewState["DataSet"] = ds;

            if (ds.Tables["Student"].Rows.Count>0)
            {
                DataRow dr = ds.Tables["Student"].Rows[0];
                txtName.Text = dr["Name"].ToString();
                ddlGender.SelectedValue = dr["Gender"].ToString();
                txtTotalMarks.Text = dr["TotalMarks"].ToString();
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No Studet Record With ID=" + txtID.Text;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string SqlQuery =(string)ViewState["SqlQuery"];
            SqlDataAdapter da = new SqlDataAdapter(SqlQuery, CS);
            da.SelectCommand.Parameters.AddWithValue("@ID", txtID.Text);
            DataSet ds = (DataSet)ViewState["DataSet"];

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            
            if(ds.Tables["Student"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["Student"].Rows[0];
                dr["Name"] = txtName.Text;
                dr["Gender"] = ddlGender.SelectedValue;
                dr["TotalMarks"] = txtTotalMarks.Text;
            }
            da.Update(ds, "Student");

            lblInsert.Text = cb.GetInsertCommand().CommandText;
            lblDelate.Text = cb.GetUpdateCommand().CommandText;
            lblUpdate.Text = cb.GetDeleteCommand().CommandText;
        }
    }
}