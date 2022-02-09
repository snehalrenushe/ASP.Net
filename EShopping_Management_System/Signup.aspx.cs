using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_Warning.Text = "Please Fill all the Fields";
        lbl_Warning.ForeColor = System.Drawing.Color.Red;
    }

    private void Clear_Controls()
    {
        tb_Name.Text = "";
        tb_Password.Text = "";
        tb_Confirm_Password.Text = "";
        tb_Username.Text = "";
        tb_Email.Text = string.Empty;
    }

    protected void txtsignup_Click(object sender, EventArgs e)
    {
        if (isformvalid())
        {
            using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
            {
                Con.Open();
                
                SqlCommand cmd = new SqlCommand("Insert into Signup (Username,Password,Confirm_Password,Email,Name,User_Role) Values('" + tb_Username.Text + "','" + tb_Password.Text + "','" + tb_Confirm_Password.Text + "','" + tb_Email.Text + "','" + tb_Name.Text + "','User')", Con);
                
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Registration Successfully done!!! ');</script>");
                Clear_Controls();

                lbl_Warning.Text = "Please Fill the all the Field";
                lbl_Warning.ForeColor = System.Drawing.Color.Red;

                Con.Close();
            }
            Response.Redirect("~/SignIn.aspx");
        }
        else
        {
            Response.Write("<script>alert('Incomplete Details !!! '); </script>");
        }
    }

    private bool isformvalid()
    {
        if (tb_Username.Text == "")
        {
            Response.Write("<script>alert('Username is not Valid.')</script>");
            tb_Username.Focus();
            return false;
        }
        else if(tb_Password.Text == "")
        {
            Response.Write("<script>alert('Password is not Valid.')</script>");
            tb_Password.Focus();
            return false;
        }
        else if (tb_Password.Text != tb_Confirm_Password.Text)
        {
            Response.Write("<script>alert('Confirm Password is not Valid.')</script>");
            return false;
        }
        else if (tb_Name.Text == "")
        {
            Response.Write("<script>alert('Name is not Valid.')</script>");
            tb_Name.Focus();
            return false;
        }
        else if (tb_Email.Text == "")
        {
            Response.Write("<script>alert('Email is not Valid.')</script>");
            tb_Email.Focus();
            return false;
        }

        return true;
    }
}