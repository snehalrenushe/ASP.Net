using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class RecoverPassword : System.Web.UI.Page
{
    int Uid;
    protected void Page_Load(object sender, EventArgs e)
    {
        String GUIDvalue;
        
        DataTable dt = new DataTable();

        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            GUIDvalue = Request.QueryString["id"];

            if (GUIDvalue != null)
            {
                SqlCommand cmd = new SqlCommand("Select * from ForgotPass where ID=@Id", Con);
                Con.Open();
                cmd.Parameters.AddWithValue("@Id", GUIDvalue);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
                Uid = Convert.ToInt32(dt.Rows[0][1]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        if (!IsPostBack)
        {
            if (dt.Rows.Count != 0)
            {
                tb_Confirm_Password.Visible = true;
                tb_New_Password.Visible = true;
                lblConfirmPassword.Visible = true;
                lblNewPassword.Visible = true;
                btn_Reset_Pass.Visible = true;
            }
            else
            {
                lblMsg.Text = "Your Password Reset Link is Expired or Invalid...try again";
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }

        }
    }
    protected void btn_Reset_Pass_Click(object sender, EventArgs e)
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Update Signup set Password=@p,Confirm_Password=@cp where Uid=@Uid", Con);
            cmd.Parameters.AddWithValue("@p", tb_New_Password.Text);
            cmd.Parameters.AddWithValue("@cp", tb_Confirm_Password.Text);
            cmd.Parameters.AddWithValue("@Uid", Uid);
            cmd.ExecuteNonQuery();
            Response.Write("<script> alert('Password Reset Successfully done');</script>");
            Clear_Controls();
        }
    }

    private void Clear_Controls()
    {
        tb_Confirm_Password.Text = "";
        tb_New_Password.Text = "";
    }
}