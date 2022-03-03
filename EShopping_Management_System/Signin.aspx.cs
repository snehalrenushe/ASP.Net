using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Signin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["uname"] != null && Request.Cookies["upass"] != null)
            {
                tb_Username.Text = Request.Cookies["uname"].Value;
                tb_Password.Text = Request.Cookies["upass"].Value;
                cb_Remember_Password.Checked = true;
            }
        }
    }

    private void Clear_Controls()
    {
        tb_Username.Text = "";
        tb_Password.Text = "";
    }

    protected void btn_Login_Click(object sender, EventArgs e)
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();

            SqlCommand cmd = new SqlCommand("Select * from Signup where Username=@username and Password=@pass", Con);

            //cmd.Parameters.AddWithValue("@username",tb_Username.Text);
            //cmd.Parameters.AddWithValue("@pass",tb_Password.Text);
            cmd.Parameters.Add("@username",SqlDbType.NVarChar).Value = tb_Username.Text;
            cmd.Parameters.Add("@pass",SqlDbType.NVarChar).Value = tb_Password.Text;

            SqlDataAdapter SDA = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            SDA.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                Session["USERID"] = dt.Rows[0]["Uid"].ToString();
                Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();

                if (cb_Remember_Password.Checked)
                {
                    Response.Cookies["uname"].Value = tb_Username.Text;
                    Response.Cookies["upass"].Value = tb_Password.Text;

                    Response.Cookies["uname"].Expires = DateTime.Now.AddDays(10);
                    Response.Cookies["upass"].Expires = DateTime.Now.AddDays(10);
                }
                else
                {
                    Response.Cookies["uname"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["upass"].Expires = DateTime.Now.AddDays(-1);
                }

                string U_Role;
                U_Role = dt.Rows[0][6].ToString().Trim();

                if (U_Role == "User")
                {
                    Session["Username"] = tb_Username.Text;
                    if (Request.QueryString["rurl"] != null)
                    {
                        if (Request.QueryString["rurl"] == "cart")
                        {
                            Response.Redirect("Cart.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/UserHome.aspx");
                    }

                }
                if (U_Role == "Admin")
                {
                    Session["Username"] = tb_Username.Text;
                    Response.Redirect("~/AdminHome.aspx");
                }

            }
            else
            {
                lbl_error.Text = "Invalid Username and Password";
            }

            Clear_Controls();

            //Response.Write("<script>alert('Login Successfull !!! ');</script>");
            
            //lbl_Warning.Text = "Please Fill the all the Field";
            //lbl_Warning.ForeColor = System.Drawing.Color.Red;

            Con.Close();
        }
    }
}