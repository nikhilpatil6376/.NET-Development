using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _17_SqlBulkCopyNotifyAfter
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection sourceCon=new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Products_Source;", sourceCon);
                sourceCon.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    using(SqlConnection destinationCon=new SqlConnection(CS))
                    {
                        using(SqlBulkCopy bc=new SqlBulkCopy(destinationCon))
                        {
                            bc.BatchSize = 10000;
                            bc.NotifyAfter = 500;
                            bc.SqlRowsCopied += new SqlRowsCopiedEventHandler(bc_SqlRowsCopied);
                            bc.DestinationTableName = "Products_Destination";
                            destinationCon.Open();
                            bc.WriteToServer(rdr);
                        }
                    }
               
                }
            }
        }
        protected void bc_SqlRowsCopied(object sender,SqlRowsCopiedEventArgs e)
        {
            Response.Write(e.RowsCopied + "loaded...."+"<br/>");
        }
    }
}