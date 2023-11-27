using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _18_Transactions
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetData();
            }
        }

        private void GetData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con=new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Accounts",con);
                con.Open();
                using(SqlDataReader rdr=cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        if (rdr["AccountNumber"].ToString()=="A1")
                        {
                            lblAccountNumber1.Text = "A1";
                            lblName1.Text = rdr["CustomerName"].ToString();
                            lblBalance1.Text = rdr["Balance"].ToString();
                        }
                        else
                        {
                            lblAccountNumber2.Text = "A2";
                            lblName2.Text = rdr["CustomerName"].ToString();
                            lblBalance2.Text = rdr["Balance"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlTransaction transaction =con.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update Accounts set Balance = Balance - 10 where AccountNumber = 'A1'", con,transaction);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("Update Accounts set Balance = Balance + 10 where AccountNumber = 'A2'", con,transaction);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    lblMessage.Text = "Transaction Successfull";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                catch
                {
                    transaction.Rollback();
                    lblMessage.Text = "Transaction Failed";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                GetData();
            }
        }
    }
}