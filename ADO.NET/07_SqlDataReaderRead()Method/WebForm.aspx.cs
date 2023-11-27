using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _07_SqlDataReaderRead__Method
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from ProductInventoryTable", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("Id");
                    table.Columns.Add("Name");
                    table.Columns.Add("Qty");
                    table.Columns.Add("Price");
                    table.Columns.Add("DiscountedPrice");

                    while(rdr.Read())
                    {
                        DataRow dataRow = table.NewRow();
                        int originalPrice = Convert.ToInt32(rdr["Price"]);
                        double discountedPrice = originalPrice * 0.9;

                        dataRow["Id"] = rdr["Id"];
                        dataRow["Name"] = rdr["ProductName"];
                        dataRow["Qty"] = rdr["QuantityAvailable"];
                        dataRow["Price"] = originalPrice;
                        dataRow["DiscountedPrice"] =discountedPrice;
                        table.Rows.Add(dataRow);
                    }
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }

            }
        }
    }
}