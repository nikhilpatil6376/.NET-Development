using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _14_StronglyTypedDatasets
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                StudentDataSetTableAdapters.StudentsTableAdapter studentsTableAdapter = new StudentDataSetTableAdapters.StudentsTableAdapter();
                StudentDataSet.StudentsDataTable studentDataTable = new StudentDataSet.StudentsDataTable();
                studentsTableAdapter.Fill(studentDataTable);

                Session["DATATABLE"] = studentDataTable;

                GridView.DataSource = from student in studentDataTable
                                      select new
                                      {
                                          student.ID,
                                          student.Name,
                                          student.Gender,
                                          student.TotalMarks
                                      };
                GridView.DataBind();
            }

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            StudentDataSet.StudentsDataTable studentDataTable = (StudentDataSet.StudentsDataTable)Session["DATATABLE"];
            if(string.IsNullOrEmpty(TextBox.Text.ToString()))
            {
                GridView.DataSource = from student in studentDataTable
                                      select new
                                      {
                                          student.ID,
                                          student.Name,
                                          student.Gender,
                                          student.TotalMarks
                                      };
                GridView.DataBind();
            }
            else
            {
                GridView.DataSource = from student in studentDataTable
                                      where student.Name.ToUpper().StartsWith(TextBox.Text.ToUpper())
                                      select new
                                      {
                                          student.ID,
                                          student.Name,
                                          student.Gender,
                                          student.TotalMarks
                                      };
                GridView.DataBind();
            }
        }
    }
}