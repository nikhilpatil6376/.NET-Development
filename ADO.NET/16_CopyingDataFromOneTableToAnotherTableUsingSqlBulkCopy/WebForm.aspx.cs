using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _16_CopyingDataFromOneTableToAnotherTableUsingSqlBulkCopy
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
           string sourceCS = ConfigurationManager.ConnectionStrings["SourceDBCS"].ConnectionString;
           string destinationCS = ConfigurationManager.ConnectionStrings["DestinationDBCS"].ConnectionString;

           using(SqlConnection sourceCon=new SqlConnection(sourceCS))
            {
                SqlCommand cmd = new SqlCommand("select * from Departments", sourceCon);
                sourceCon.Open();
                using(SqlDataReader rdr=cmd.ExecuteReader())
                {
                    using(SqlConnection destinationCon=new SqlConnection(destinationCS))
                    {
                        using(SqlBulkCopy bc=new SqlBulkCopy(destinationCS))
                        {
                            bc.DestinationTableName = "Departments";
                            destinationCon.Open();
                            bc.WriteToServer(rdr);
                        }
                    }
                }

                cmd = new SqlCommand("select * from Employees", sourceCon);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    using (SqlConnection destinationCon = new SqlConnection(destinationCS))
                    {
                        using (SqlBulkCopy bc = new SqlBulkCopy(destinationCS))
                        {
                            bc.DestinationTableName = "Employees";
                            destinationCon.Open();
                            bc.WriteToServer(rdr);
                        }
                    }
                }
            }
        }
    }
}