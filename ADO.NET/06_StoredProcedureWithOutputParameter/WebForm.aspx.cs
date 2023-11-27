using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace _06_StoredProcedureWithOutputParameter
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                /*
                    create procedure spAddEmployee
                    @Name nvarchar(10),
                    @Gender nvarchar(10),
                    @Salary int,
                    @EmployeeId int out
                    As
                    Begin
                    	insert into EmployeeTable values(@Name,@Gender,@Salary)
                    	select @EmployeeId=SCOPE_IDENTITY();
                    End

                    declare @EmpId int;
                    execute spAddEmployee 'Geetesh',Male,32000,@EmpId out
                    print 'Employee Id' + cast(@empid as nvarchar(2));
                 */

                SqlCommand cmd = new SqlCommand("spAddEmployee",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", txtEmpName.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", txtEmpSalary.Text);

                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@EmployeeId";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);

                con.Open();
                cmd.ExecuteNonQuery();
                string EmployeeId = outputParameter.Value.ToString();
                lblEmpId.Text = "Employee Id =" + EmployeeId;
            }
            
        }
    }
}