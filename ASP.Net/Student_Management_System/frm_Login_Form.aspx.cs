using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;                

public partial class frm_Login_Form : System.Web.UI.Page
{
    SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DB_Student_Management_System;Integrated Security=True");
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void tb_Password_TextChanged(object sender, EventArgs e)
    {
        btn_Submit.Enabled = true;
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        Con.Open();

        SqlCommand Cmd = new SqlCommand();

        Cmd.Connection = Con;

        Cmd.CommandText = "Select * from Login where Username = @uname And Password = @pass";

        Cmd.Parameters.Add("uname", SqlDbType.NVarChar).Value = tb_Username.Text;
        Cmd.Parameters.Add("pass", SqlDbType.NVarChar).Value = tb_Password.Text;

        string Ret = Convert.ToString(Cmd.ExecuteScalar());

        if (Ret == tb_Username.Text && tb_Username.Text != "")
        {
            Response.Write("<script>window.alert('Login Successsfullyyyy !!!!!')</script>");

            Response.Redirect("MDI_Student_Management_System.master");

        }
        else
        {
            Response.Write("<script>alert('Invalid Username and Password!!!!')</script>");
        }

        Con.Close();
    }
}