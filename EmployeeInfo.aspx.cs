using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridEmpDetails();
        }
    }

    protected void BindGridEmpDetails()
    {
        SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=EmployeeDetails;Integrated Security=True");
        SqlCommand objCommand = new SqlCommand("Select * from EmployeeRecords", objConnection);
        SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
        DataSet ds = new DataSet();
        objAdapter.Fill(ds);

        gvEmpDetails.DataSource = ds;
        gvEmpDetails.DataBind();
    }

    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=EmployeeDetails;Integrated Security=True");
        SqlCommand objCommand = new SqlCommand("insert into EmployeeRecords (Name, Address, Mobile) values (@Name, @Address, @Mobile)", objConnection);
        objCommand.Parameters.AddWithValue("@Name", txtName.Text);
        objCommand.Parameters.AddWithValue("@Address", txtAddress.Text);
        objCommand.Parameters.AddWithValue("@Mobile", txtPhone.Text);
        objConnection.Open();
        objCommand.ExecuteNonQuery();
        objConnection.Close();
       
        gvEmpDetails.DataBind();
        Response.Write("Successfully Added");
    }

    protected void gvEmpDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int row = e.RowIndex;
        string id = gvEmpDetails.Rows[row].Cells[0].Text;
        SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=EmployeeDetails;Integrated Security=True");
        SqlCommand objCommand = new SqlCommand("delete from EmployeeRecords where EmpId = '"+ id +"'", objConnection);
        objConnection.Open();
        objCommand.ExecuteNonQuery();
        objConnection.Close();

        gvEmpDetails.DataBind();
        Response.Write("Successfully Deleted");
    }


    protected void gvEmpDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmpDetails.EditIndex = -1;
        BindGridEmpDetails();
    }


    protected void gvEmpDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int row = e.NewEditIndex;
        gvEmpDetails.EditIndex = row;
        BindGridEmpDetails();
    }


    protected void gvEmpDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int row = e.RowIndex;
        string name = ((TextBox)gvEmpDetails.Rows[row].Cells[1].Controls[0]).Text;
        string address = ((TextBox)gvEmpDetails.Rows[row].Cells[2].Controls[0]).Text;
        string mobile = ((TextBox)gvEmpDetails.Rows[row].Cells[3].Controls[0]).Text;
        int id =  Convert.ToInt32(gvEmpDetails.DataKeys[e.RowIndex].Value);
        SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=EmployeeDetails;Integrated Security=True");
        objConnection.Open();
        SqlCommand objCommand = new SqlCommand("update EmployeeRecords set Name = '"+ name +"', Address = '"+ address+"', Mobile = '"+ mobile+"' where EmpId = '"+ id +"'", objConnection);
        objCommand.ExecuteNonQuery();
        gvEmpDetails.EditIndex = -1;
        BindGridEmpDetails();
        objConnection.Close();

        Response.Write("Successfully Updated");
    }
}