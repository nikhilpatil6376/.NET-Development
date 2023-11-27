using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _15_LoadxmlDataIntoSqlServerTableUsingSqlbulkcopy
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/Data.xml"));

                DataTable dtEmp = ds.Tables["Employee"];
                DataTable dtDept = ds.Tables["Department"];
                con.Open();

                using (SqlBulkCopy bc = new SqlBulkCopy(con))
                {
                    bc.DestinationTableName = "Employees";
                    bc.ColumnMappings.Add("ID", "ID");
                    bc.ColumnMappings.Add("Name", "Name");
                    bc.ColumnMappings.Add("Gender", "Gender");
                    bc.ColumnMappings.Add("DepartmentId", "DepartmentId");
                    bc.WriteToServer(dtEmp);
                }

                using (SqlBulkCopy bc = new SqlBulkCopy(con))
                {
                    bc.DestinationTableName = "Departments";
                    bc.ColumnMappings.Add("ID", "ID");
                    bc.ColumnMappings.Add("Name", "Name");
                    bc.ColumnMappings.Add("Location", "Location");
                    bc.WriteToServer(dtDept);
                }
            }

        }
    }
}