using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace _13_DisconnectedDataAccess
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetDataFromDataBase()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string Query = "Select * From StudentTable";
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataSet ds = new DataSet();
            da.Fill(ds,"Students");

            ds.Tables["Students"].PrimaryKey = new DataColumn[] { ds.Tables["Students"].Columns["ID"] };
            Cache.Insert("DATASET",ds,null,DateTime.Now.AddHours(24),System.Web.Caching.Cache.NoSlidingExpiration);

            gvStudents.DataSource = ds;
            gvStudents.DataBind();
            lblMessage.Text = "Data is loaded from DataBase";
        }

        private void GetDataFromCache()
        {
            if (Cache["DATASET"]!=null)
            {
                gvStudents.DataSource = (DataSet)Cache["DATASET"];
                gvStudents.DataBind();
                lblMessage.Text = "Data is loaded from Cache";
            }
        }
        protected void btnGetDataFromDB_Click(object sender, EventArgs e)
        {
            GetDataFromDataBase();
        }

        protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStudents.EditIndex = e.NewEditIndex;
            GetDataFromCache();
        }

        protected void gvStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["DATASET"]!=null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr=ds.Tables["Students"].Rows.Find(e.Keys["ID"]);
                dr["Name"] = e.NewValues["Name"];
                dr["Gender"] = e.NewValues["Gender"];
                dr["TotalMarks"] = e.NewValues["TotalMarks"];
                gvStudents.EditIndex = -1;
                GetDataFromCache();
            }
        }

        protected void gvStudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudents.EditIndex = -1;
            GetDataFromCache();
        }

        protected void gvStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            ds.Tables["Students"].Rows.Find(e.Keys["ID"]).Delete();
            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            GetDataFromCache();
        }
        protected void btnUpdateDataIntoDatabase_Click(object sender, EventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                string Query = "Select * From StudentTable";
                SqlDataAdapter da = new SqlDataAdapter(Query, con);

                string strUpdateCommand = "Update StudentTable Set Name=@Name, Gender=@Gender, TotalMarks=@TotalMarks where ID=@ID";
                SqlCommand updateCommand = new SqlCommand(strUpdateCommand, con);
                updateCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
                updateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 20, "Name");
                updateCommand.Parameters.Add("@Gender", SqlDbType.NVarChar, 20, "Gender");
                updateCommand.Parameters.Add("@TotalMarks", SqlDbType.Int, 0, "TotalMarks");
                da.UpdateCommand = updateCommand;

                string strDeleteCommand = "delete from StudentTable where ID=@ID";
                SqlCommand deleteCommand = new SqlCommand(strDeleteCommand, con);
                deleteCommand.Parameters.Add("@ID", SqlDbType.NVarChar, 0, "ID");
                da.DeleteCommand = deleteCommand;

                da.Update((DataSet)Cache["DATASET"], "Students");
                lblMessage.Text = "Database Is Updated";
            }
        }

        protected void btnGetRowsState_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];

            //Inserted State
            //DataRow InsertedRow = ds.Tables["Students"].NewRow();
            //InsertedRow["ID"] = 6;
            //ds.Tables["Students"].Rows.Add(InsertedRow);


            foreach (DataRow dr in ds.Tables["Students"].Rows)
            {
                if(dr.RowState==DataRowState.Deleted)
                {
                    Response.Write(dr["ID",DataRowVersion.Original].ToString() + " " + dr.RowState.ToString() + "<br/>");
                }
                else
                {
                    Response.Write(dr["ID"].ToString() + " " + dr.RowState.ToString() + "<br/>");
                }
            }
            //Detached State
            //DataRow DetachedRow = ds.Tables["Students"].NewRow();
            //DetachedRow["ID"] = 7;
            //Response.Write(DetachedRow["ID"] + " " + DetachedRow.RowState.ToString());

        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            if (ds.HasChanges())
            {
                ds.AcceptChanges();
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                GetDataFromCache();
                lblStateMessage.Text = "Changes Are Saved";
                lblStateMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStateMessage.Text = "Nothing To Save Changes";
                lblStateMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUndoChanges_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            if (ds.HasChanges())
            {
                ds.RejectChanges();
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                GetDataFromCache();
                lblStateMessage.Text = "Changes Are Undo";
                lblStateMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStateMessage.Text = "Nothing To Undo Changes";
                lblStateMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}